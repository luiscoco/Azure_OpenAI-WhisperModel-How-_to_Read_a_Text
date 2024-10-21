# How to convert MP3 audio file to Text with Azure OpenAI Whisper model

**Note**: for converting the Audio **m4a** file (created with the Recorder application) into **mp3** file please use this link:

https://cloudconvert.com/m4a-to-mp3

## 1. Create an Azure OpenAI service and deploy a Whisper model

![image](https://github.com/user-attachments/assets/fedb0707-ded5-49d8-8600-0c3800612811)

![image](https://github.com/user-attachments/assets/4f790b07-e67b-4a89-be08-6bafdf14996c)

![image](https://github.com/user-attachments/assets/16b24ccd-e549-4468-99f6-0525d02a4e64)

## 2. Create a C# Console application with Visual Studio 2022

We run Visual Studio 2022 and create a new project

![image](https://github.com/user-attachments/assets/5f533b22-1dc5-488f-9941-712cb704d718)

We select the project templaste

![image](https://github.com/user-attachments/assets/e29b69a6-2887-438f-a185-f8d06038afcd)

We input the project name and location 

![image](https://github.com/user-attachments/assets/757dc0c9-2265-4036-bc1e-eefc2008543c)

We select the .NET 8 framework and press the Create button

![image](https://github.com/user-attachments/assets/a9259bcd-b420-4950-9d79-41cfebd8e2fb)

We load the **Nuget packages**:

![image](https://github.com/user-attachments/assets/38390598-1945-4be7-9731-b6d35463dfc3)

We verify the application folders and files structure:

![image](https://github.com/user-attachments/assets/0723ddef-88d0-4402-a189-a7fef44e42ca)

This is the application source code:

```csharp
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity; // Required for Passwordless auth

var endpoint = new Uri("https://whisperluismodel.openai.azure.com/");
var credentials = new AzureKeyCredential("58b40a57c13d475184e472aa58dd392d");

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
```

## 3. We run the application and see the result

![image](https://github.com/user-attachments/assets/6c53e365-bb20-4d99-a2e0-6f5ceb94036e)
