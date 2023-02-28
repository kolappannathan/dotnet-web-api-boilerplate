using API.Operations.Interfaces;

namespace API.Operations;

public sealed class ValueLib : IValueLib
{
    private string[] _values = { "Jon Snow", "Rob Stark", "Sansa Stark", "Arya Stark", "Bran Stark", "Rickon Stark" };

    public ValueLib(IConfiguration configuration)
    {
    }

    public string[] GetValueList() => _values;

    public string GetValueById(int id) => _values.Length <= id ? string.Empty : _values[id];

    public int AddValue(string value) => 1;

    public int UpdateValue(string value, int id) => _values.Length <= id ? -1 : 1;

    public int DeleteValue(int id) => _values.Length <= id ? -1 : 1;

}
