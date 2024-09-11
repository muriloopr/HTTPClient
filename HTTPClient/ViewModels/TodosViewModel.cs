using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTTPClient.ViewModels
{
    public partial class TodosViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> todos;

        private ICommand getTodosCommand { get; }

        public TodosViewModel()
        {
            getTodosCommand = new Command(getTodos);
        }

        public async void getTodos()
        {
            TodosService todosService = new TodosService();
            todos = await todosService.getTodos();
        }
    }
}
