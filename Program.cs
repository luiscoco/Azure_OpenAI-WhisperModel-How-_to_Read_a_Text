using Azure;
using Azure.AI.OpenAI;
using Azure.Identity; // Required for Passwordless auth

var endpoint = new Uri("https://whisperluismodel.openai.azure.com/");
var credentials = new AzureKeyCredential("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

var deploymentName = "whisper"; // Default deployment name, update with your own if necessary
var audioFilePath = "C:\\14. Blazor LCE Youtube channel\\file1.mp3";

var openAIClient = new AzureOpenAIClient(endpoint, credentials);

var audioClient = openAIClient.GetAudioClient(deploymentName);

var result = await audioClient.TranscribeAudioAsync(audioFilePath);

Console.WriteLine("Transcribed text:");
foreach (var item in result.Value.Text)
{
    Console.Write(item);
}
