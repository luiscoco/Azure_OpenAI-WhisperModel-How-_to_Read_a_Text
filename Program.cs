using Azure;
using Azure.AI.OpenAI;
using Azure.Identity; // Required for Passwordless auth

var endpoint = new Uri("YOUR_OPENAI_ENDPOINT");
var credentials = new AzureKeyCredential("YOUR_OPENAI_KEY");

var deploymentName = "whisper"; // Default deployment name, update with your own if necessary
var audioFilePath = "C:\\AzureOpenAI_WhisperModel\\";

var openAIClient = new AzureOpenAIClient(endpoint, credentials);

var audioClient = openAIClient.GetAudioClient(deploymentName);

var result = await audioClient.TranscribeAudioAsync(audioFilePath);

Console.WriteLine("Transcribed text:");
foreach (var item in result.Value.Text)
{
    Console.Write(item);
}