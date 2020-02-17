using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todos;
using System.Net.Http;

namespace BlazorTodo.Pages
{
    public class MyTodosCodebehindBase : ComponentBase
    {
        [Inject] 
        private HttpClient Http { get; set; }

        private readonly string todoApi = "https://localhost:44358/api/todos";
        protected string newTodo;

        protected List<Todo> Todos { get; set; } = new List<Todo>();

        protected override async Task OnInitializedAsync()
        {
            Todos = await Http.GetJsonAsync<List<Todo>>(todoApi);
        }

        protected async Task AddTodo()
        {
            await Http.PostJsonAsync(todoApi, new Todo { Name = newTodo });

            Todos = await Http.GetJsonAsync<List<Todo>>(todoApi);

            newTodo = null;
        }

        protected async Task MarkCompleted(bool isComplete, Todo todo)
        {
            todo.IsComplete = isComplete;

            await Http.PostJsonAsync($"{todoApi}/{todo.Id}", todo);
        }

        protected async Task DeleteTodo(Todo todo)
        {
            await Http.DeleteAsync($"{todoApi}/{todo.Id}");

            Todos = await Http.GetJsonAsync<List<Todo>>(todoApi);
        }
    }
}
