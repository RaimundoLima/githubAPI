using AutoMapper;
using github.Domain.DTO;
using github.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Repository = github.Domain.Entity.Repository;
using Branch = github.Domain.Entity.Branch;
using Webhook = github.Domain.Entity.Webhook;


namespace githubAPI.Controllers
{
    [ApiController]
    [Route("/repository")]
    public class RepositoryController : Controller
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IBranchService _branchService;
        private readonly IWebhookService _webhookService;
        private readonly IMapper _repositoryMapper;
        private readonly IMapper _branchMapper;
        private readonly IMapper _webhookMapper;
        public RepositoryController(IRepositoryService repositoryService,
            IBranchService branchService,
            IWebhookService webhookService,
            IMapper repositoryMapper,
            IMapper branchMapper,
            IMapper webhookMapper)
        {
            _repositoryService = repositoryService;
            _branchService = branchService;
            _webhookService = webhookService;
            _repositoryMapper = repositoryMapper;
            _branchMapper = branchMapper;
            _webhookMapper = webhookMapper;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRepositoryAsync(CreateRepositoryDTO model)
        {
            try
            {
                Repository entity = _repositoryMapper.Map<Repository>(model);
                return Created("",_repositoryMapper.Map<ViewRepositoryDTO>(await _repositoryService.CreateRepository(entity)));
            }
            catch (Exception ex) {
            
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("repository/{repositoryId}/branch")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListBranchsAsync(int repositoryId)
        {
            try
            {
                List<Branch> branches = _branchMapper.Map<List<Branch>>(await _branchService.ListBranchs(repositoryId));
                List<ViewBranchDTO> result = _branchMapper.Map<List<ViewBranchDTO>>(branches);
                if (result.Count == 0)
                    return NotFound();
                
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("repository/{repositoryId}/webhook")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateWebhooksAsync(int repositoryId, CreateWebhookDTO model)
        {
            try
            {
                Webhook entity = _repositoryMapper.Map<Webhook>(model);
                entity.RepositoryId = repositoryId;
                return Created("",_webhookMapper.Map<ViewWebhookDTO>(await _webhookService.CreateWebhook(entity)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("repository/{repositoryId}/webhook")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateWebhooksAsync(int repositoryId, UpdateWebhookDTO model)
        {
            try
            {
                Webhook entity = _repositoryMapper.Map<Webhook>(model);
                entity.RepositoryId = repositoryId;
                return Ok(_webhookMapper.Map<ViewWebhookDTO>(await _webhookService.UpdateWebhook(entity)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("repository/{repositoryId}/webhooks")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListWebhooksAsync(int repositoryId)
        {
            try
            {
                List<Webhook> webhooks = await _webhookService.ListWebhooks(repositoryId);
                List<ViewWebhookDTO> result = _webhookMapper.Map<List<ViewWebhookDTO>>(webhooks);
                if (result.Count == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
