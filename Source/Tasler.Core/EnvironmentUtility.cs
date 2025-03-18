using System.Collections;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public static class EnvironmentUtility
{
	#region Methods
	public static IDictionary ReplaceEnvironmentVariables(IDictionary newEnvironmentVariables)
	{
		// Save the current set of environment variables
		IDictionary previousEnvironmentVariables = Environment.GetEnvironmentVariables();

		// Remove all current environment variables
		foreach (string variable in previousEnvironmentVariables.Keys)
			Environment.SetEnvironmentVariable(variable, null);

		// Set the new environment
		foreach (DictionaryEntry entry in newEnvironmentVariables)
			Environment.SetEnvironmentVariable((string)entry.Key, (string?)entry.Value);

		// Return the previous set of environment variables
		return previousEnvironmentVariables;
	}
	#endregion Methods
}
