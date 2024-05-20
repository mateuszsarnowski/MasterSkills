using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkillsWeb.Client.HttpRepository.Interfaces;
using System.Net.Http.Json;

namespace MasterSkillsWeb.Client.HttpRepository
{
    public class NoteHttpRepository : INoteHttpRepository
    {
        private readonly HttpClient _client;

        public NoteHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<NoteDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<NoteDto>>($"Notes");
        }
    }
}
