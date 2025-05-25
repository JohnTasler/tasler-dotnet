
namespace Tasler.Configuration;

public interface ISettingsStore
{
	T GetValue<T>(string valueName);
	T GetValue<T>(string valueName, T defaultValue);
	bool SetValue<T>(string valueName, T value);
}
