using MasterSkills.Application.Features.Notes.Commands.CreateNote;
using MasterSkills.Application.Features.Notes.Commands.DeleteNote;
using MasterSkills.Application.Features.Notes.Commands.UpdateNote;
using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkills.Application.Features.Notes.Queries.Notes.GetNoteDetails;
using MasterSkills.Domain.Entities.Notes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterSkills.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<NoteDto>> Get()
        {
            var notes = await _mediator.Send(new GetNotesQuery());
            return notes;
        }

        [HttpGet("{id}")]
        public async Task<NoteDetailsDto> Get(int id)
        {
            var noteDetails = await _mediator.Send(new GetNoteDetailsQuery(id));
            return noteDetails;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateNoteCommand note)
        {
            var response = await _mediator.Send(note);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateNoteCommand note)
        {
            var response = await _mediator.Send(note);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteNoteCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
