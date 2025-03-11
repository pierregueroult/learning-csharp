# ✅ What This Project Taught Me in C#

## 🏗 Building a Desktop App with Avalonia
- Using Avalonia to create cross-platform UIs
- Understanding XAML structure for UI layout
- Binding UI elements to a ViewModel

## 🎭 Data Binding and MVVM Pattern
- Implementing the **MVVM** (Model-View-ViewModel) pattern
- Binding `TextBox`, `TextBlock`, and `Button` to ViewModel properties
- Using `INotifyPropertyChanged` to update UI dynamically

## 🎛 Working with Observable Collections
- `ObservableCollection<T>` for dynamic UI updates when adding/removing notes
- `ListBox.ItemsSource = Notes` to display a list dynamically

## 🎨 UI State Management
- Toggling edit mode with `IsEditing` property
- Conditional visibility with `BoolToVisibilityConverter`

## 📂 File I/O in C#
- Reading and writing text files using:
```c#
File.WriteAllLines("notes.txt", Notes.Select(n => n.Text));
File.ReadAllLines("notes.txt");
```
- Checking if a file exists before reading

## 🛠 Custom Commands and Event Handling
- Creating custom **RelayCommand** for handling button clicks:
```c#
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    public event EventHandler? CanExecuteChanged;
    public RelayCommand(Action execute) => _execute = execute;
    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => _execute();
}
```
- Binding commands in XAML for buttons

## 🔄 Editing and Saving Notes Dynamically
- Switching between **view mode** (TextBlock) and **edit mode** (TextBox)
- Saving the edited note back to the list

## 🖱 Handling Click Events in Avalonia
- Button click event handling with `Command` in XAML
- `EditCommand`, `DeleteCommand`, and `SaveCommand` linked to UI buttons