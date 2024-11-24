using System.Collections.Generic;
using System.Windows;

namespace malkowwy
{
    public partial class ListWindow : Window
    {
        private List<string> employees;

        public ListWindow()
        {
            InitializeComponent();
            employees = new List<string>();
            UpdateList();
        }

        private void UpdateList()
        {
            ListBox.Items.Clear();
            foreach (var employee in employees)
            {
                ListBox.Items.Add(employee);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string newEmployee = Microsoft.VisualBasic.Interaction.InputBox("Введите имя сотрудника:", "Добавить сотрудника", "");
            if (!string.IsNullOrWhiteSpace(newEmployee))
            {
                employees.Add(newEmployee);
                UpdateList();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                employees.Remove(ListBox.SelectedItem.ToString());
                UpdateList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string selectedEmployee = ListBox.SelectedItem.ToString();
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Редактировать имя сотрудника:", "Редактировать сотрудника", selectedEmployee);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    int index = employees.IndexOf(selectedEmployee);
                    employees[index] = newName;
                    UpdateList();
                }
            }
        }
    }
}