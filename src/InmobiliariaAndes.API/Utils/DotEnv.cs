namespace InmobiliariaAndes.API.Utils;

public static class DotEnv
{
    public static void Load(string filePath = ".env")
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The .env file '{filePath}' does not exist.");
        }
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                continue; // Skip empty lines and comments
            }
            var parts = line.Split('=', 2);
            if (parts.Length == 2)
            {
                Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
            }
        }
    }
}
