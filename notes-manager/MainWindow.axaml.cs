using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace notes_manager;

public partial class MainWindow : Window
{
    public ObservableCollection<NoteViewModel> Notes { get; } = [];
    private const string FilePath = "notes.txt";

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        NotesList.ItemsSource = Notes;
        LoadNotes();

        AddNoteButton.Click += AddNote;
    }

    private void AddNote(object? sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NoteInput.Text))
        {
            Notes.Add(new NoteViewModel(NoteInput.Text, EditNote, DeleteNote, SaveNote));
            NoteInput.Text = "";
            SaveNotes();
        }
    }

    private void EditNote(NoteViewModel note)
    {
        note.IsEditing = !note.IsEditing;
    }

    private void DeleteNote(NoteViewModel note)
    {
        Notes.Remove(note);
        SaveNotes();
    }

    private void SaveNote(NoteViewModel note)
    {
        note.IsEditing = false;
        SaveNotes();
    }

    private void SaveNotes()
    {
        File.WriteAllLines(FilePath, Notes.Select(note => note.Text));
    }

    private void LoadNotes()
    {
        if (File.Exists(FilePath))
        {
            foreach (var line in File.ReadAllLines(FilePath))
            {
                Notes.Add(new NoteViewModel(line, EditNote, DeleteNote, SaveNote));
            }
        }
    }
}

public class NoteViewModel: INotifyPropertyChanged
{
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SaveCommand { get; }
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _text = string.Empty;
    private bool _isEditing;

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    public bool IsEditing
    {
        get => _isEditing;
        set
        {
            _isEditing = value;
            OnPropertyChanged(nameof(IsEditing));
        }
    }


    public NoteViewModel(string text, Action<NoteViewModel> editAction, Action<NoteViewModel> deleteAction, Action<NoteViewModel> saveAction)
    {
        Text = text;
        EditCommand = new RelayCommand(() => editAction(this));
        DeleteCommand = new RelayCommand(() => deleteAction(this));
        SaveCommand = new RelayCommand(() => saveAction(this));
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class RelayCommand(Action execute) : ICommand
{
    private readonly Action _execute = execute;
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => _execute();
}