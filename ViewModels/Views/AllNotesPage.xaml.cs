csharp
    using Notes.Models;

namespace Notes.Views;

[QueryProperty(nameof(ItemId), "load")]
public partial class NotePage : ContentPage
{
    string _fileName;
    Note note;

    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
    {
        InitializeComponent();
        note = new Note();
        note.Date = DateTime.Now;
        _fileName = Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.txt");
        BindingContext = note;
    }

    private void LoadNote(string fileName)
    {
        _fileName = fileName;
        if (File.Exists(_fileName))
        {
            note.Text = File.ReadAllText(_fileName);
            note.Date = File.GetLastWriteTime(_fileName);
        }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        note.Date = DateTime.Now;
        File.WriteAllText(_fileName, note.Text);
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        note.Text = string.Empty;
        await Shell.Current.GoToAsync("..");
    }
}
