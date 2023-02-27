namespace API.Operations.Interfaces;

public interface IValueLib
{
    public string[] GetValueList();
    public string GetValueById(int id);
    public int AddValue(string value);
    public int UpdateValue(string value, int id);
    public int DeleteValue(int id);
}
