Imports System.IO
Imports System.Convert
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1
    Sub Main()
        Dim basePath As String = "C:/Users/Admin/Documents/stupid cs thing/json/"
        Dim basePath2 As String = "C:/Users/Admin/Documents/stupid cs thing/jframes/"
        Dim iPath As String = "C:/Users/Admin/Documents/stupid cs thing/frames/"
        Dim mask As JObject = JObject.Parse(File.ReadAllText(basePath & "0mask.json"))
        For i As Integer = 1 To 6572
            Dim currentFrame As String = i.ToString("D4")
            mask("title") = "Frame: " & currentFrame & "/6572"
            Console.WriteLine("Current Frame: " + currentFrame + "/6572")
            Dim imgPath As String = iPath & "ba-" & currentFrame & ".bmp"
            Dim imgBytes() As Byte = File.ReadAllBytes(imgPath)
            Dim imgBase64 As String = ToBase64String(imgBytes)
            mask("backgrounds")(0)("img") = "data:image/bmp;base64," & imgBase64
            File.WriteAllText(basePath2 & "frame-" & currentFrame & ".json", mask.ToString(Formatting.None))
        Next
    End Sub
End Module
