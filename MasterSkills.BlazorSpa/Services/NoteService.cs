using AutoMapper;
using Blazored.LocalStorage;
using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Models.Notes;
using MasterSkills.BlazorSpa.Services.Base;

namespace MasterSkills.BlazorSpa.Services
{
    public class NoteService : BaseHttpService, INoteService
    {

        private readonly IMapper _mapper;
        public NoteService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateNote(NoteVM note)
        {
            try
            {
                await AddBearerTokenAsync();
                var createLeaveTypeCommand = _mapper.Map<CreateNoteCommand>(note);
                await _client.NotesPOSTAsync(createLeaveTypeCommand);
                return new Response<Guid>
                {
                    Message = "Note created successfully",
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteNote(int id)
        {
           try
            {
                await AddBearerTokenAsync();
                await _client.NotesDELETEAsync(id);
                return new Response<Guid>
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<NoteVM> GetNoteById(int id)
        {
            await AddBearerTokenAsync();
            var response = await _client.NotesGETAsync(id);
            return _mapper.Map<NoteVM>(response);
        }

        public async Task<List<NoteVM>> GetNotes()
        {
            await AddBearerTokenAsync();
            var response = await _client.NotesAllAsync();
            return _mapper.Map<List<NoteVM>>(response);
        }

        public async Task<Response<Guid>> UpdateNote(NoteVM note)
        {
            try
            {
                await AddBearerTokenAsync();
                var updateLeaveTypeCommand = _mapper.Map<UpdateNoteCommand>(note);
                await _client.NotesPUTAsync(updateLeaveTypeCommand);
                return new Response<Guid>
                {
                    Message = "Note updated successfully",
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
