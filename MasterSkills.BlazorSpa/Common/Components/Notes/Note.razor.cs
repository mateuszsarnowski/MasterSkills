using Microsoft.AspNetCore.Components;
using MasterSkills.BlazorSpa.Common.Features;
using System.ComponentModel;
using System.Globalization;
using DateTimeConverter = MasterSkills.BlazorSpa.Common.Features.DateTimeConverter;


namespace MasterSkills.BlazorSpa.Common.Components.Notes
{
    public partial class Note : ComponentBase
    {
        public string? _date;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Content { get; set;}

        [Parameter]
        public DateTime CreatedAt { get; set; }

        protected override void OnParametersSet()
        {
            if (CreatedAt != null)
                _date = DateTimeConverter.ConvertDateToPolish(CreatedAt);
        }

    }
}
