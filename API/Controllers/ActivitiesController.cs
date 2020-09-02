using Application.Activities;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivitiesController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ActivitiesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<List<Activity>>> List () {
			return await _mediator.Send (new List.Query ());
		}

		[HttpGet ("{id}")]
		public async Task<ActionResult<Activity>> Details (Guid id, Details.Query query) {
			query.Id = id;
			return await _mediator.Send (query);
		}
		
		[HttpPost]
		public async Task<ActionResult<Unit>> Create (Create.Command command) {
			return await _mediator.Send(command);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Unit>> Update (Guid id, Update.Command command) {
			command.Id = id;
			return await _mediator.Send(command);
		}

		//[HttpDelete("{id}")]
		//public async Task<ActionResult<Unit>> Delete (Guid id, Delete.Command command) {
		//	command.Id = id;
		//	return await _mediator.Send(command);
		//}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Unit>> Delete (Guid id) {
			return await _mediator.Send(new Delete.Command{Id = id});
		}
	}
}