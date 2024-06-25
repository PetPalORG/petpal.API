using Microsoft.AspNetCore.Mvc;
using PetPalBack.Articles.Domain.Model.Queries;
using PetPalBack.Articles.Domain.Services;
using PetPalBack.Articles.Interfaces.REST.Resources;
using PetPalBack.Articles.Interfaces.REST.Transform;
using System.Net.Mime;

namespace PetPalBack.Articles.Interfaces.REST
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Article")]
    public class ArticleController(IArticleCommandService articleCommandService, IArticleQueryService articleQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleResource createArticleResource)
        {
            var createArticleCommand = CreateArticleCommandFromResourceAssembler.ToCommandFromResource(createArticleResource);
            var article = await articleCommandService.Handle(createArticleCommand);
            if (article is null) return BadRequest();
            var resource = ArticleResourceFromEntityAssembler.ToResourceFromEntity(article);
            return CreatedAtAction(nameof(GetArticleById), new { articleId = article.id }, resource);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var getAllArticlesQuery = new GetAllArticlesQuery();
            var articles = await articleQueryService.Handle(getAllArticlesQuery);
            var resources = articles.Select(ArticleResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(articles);
        }
        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetArticleById([FromRoute] int articleId)
        {
            var getArticleByIdQuery = new GetArticleByIdQuery(articleId);
            var article = await articleQueryService.Handle(getArticleByIdQuery);
            if (article is null) return NotFound();
            var resource = ArticleResourceFromEntityAssembler.ToResourceFromEntity(article);
            return Ok(resource);
        }
    }
}
