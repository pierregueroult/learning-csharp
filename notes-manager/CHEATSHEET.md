# 📜 C# Notes Manager Cheat Sheet

## 📝 Creating an ObservableCollection
```c#
public ObservableCollection<NoteViewModel> Notes { get; } = new();
```

## 📂 Loading and Saving Notes to a File
```c#
private void SaveNotes()
{
    File.WriteAllLines("notes.txt", Notes.Select(note => note.Text));
}

private void LoadNotes()
{
    if (File.Exists("notes.txt"))
    {
        foreach (var line in File.ReadAllLines("notes.txt"))
        {
            Notes.Add(new NoteViewModel(line, EditNote, DeleteNote, SaveNote));
        }
    }
}
```

## ✏️ Editing a Note
```c#
private void EditNote(NoteViewModel note)
{
    note.IsEditing = !note.IsEditing;
}
```

## 🔄 Binding UI Visibility in Avalonia
```xml
<TextBlock Text="{Binding Text}" Visibility="{Binding IsEditing, Converter={StaticResource BoolToVisibilityConverter}}"/>
<TextBox Text="{Binding Text, Mode=TwoWay}" Visibility="{Binding IsEditing, Converter={StaticResource InvertedBoolToVisibilityConverter}}"/>
```

## 🖱 Implementing Commands
```c#
public ICommand EditCommand { get; }
public ICommand DeleteCommand { get; }
public ICommand SaveCommand { get; }

public NoteViewModel(string text, Action<NoteViewModel> editAction, Action<NoteViewModel> deleteAction, Action<NoteViewModel> saveAction)
{
    Text = text;
    EditCommand = new RelayCommand(() => editAction(this));
    DeleteCommand = new RelayCommand(() => deleteAction(this));
    SaveCommand = new RelayCommand(() => saveAction(this));
}
```

## 🎛 Creating a RelayCommand
```c#
public class RelayCommand(Action execute) : ICommand
{
    private readonly Action _execute = execute;
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => _execute();
}
```

## 📦 Installing Avalonia
```bash
dotnet new -i Avalonia.Templates
dotnet new avalonia.app -n NotesManager
```

