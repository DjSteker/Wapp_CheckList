
Imports System
Imports System.Threading

Public Class Class_ConversorHex
    Sub Main()
        '#If Not VERSION_MAJOR Or Not VERSION_MINOR Or Not VERSION_PATCH Then
        '#Else' "Define version components on compiler command line!"
        '#End If

        Dim hex_version As Integer = (VERSION_MAJOR << 16) + (VERSION_MINOR << 8) + VERSION_PATCH

        Console.WriteLine("0x" & hex_version.ToString("X"))
    End Sub


    'int main()
    '{

    '    int hex_version = (VERSION_MAJOR << 16) +
    '                      (VERSION_MINOR << 8) +
    '                      (VERSION_PATCH);

    '    std:cout << std:hex << "0x" << hex_version;
    '}

End Class


Imports System
Imports System.Threading
Imports System.Collections.Generic

Module MainModule

    ' Subclass the AudioDeviceManager so we can skip WASAPI devices on Windows
    Class TestAudioDeviceManager
        Inherits juce.AudioDeviceManager

        Public Shared Sub addIfNotNull(list As juce.OwnedArray(Of juce.AudioIODeviceType), device As juce.AudioIODeviceType)
            If device IsNot Nothing Then
                list.Add(device)
            End If
        End Sub

        Public Overrides Sub createAudioDeviceTypes(list As juce.OwnedArray(Of juce.AudioIODeviceType))
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_DirectSound())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_ASIO())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_CoreAudio())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_iOSAudio())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_Bela())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_ALSA())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_JACK())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_Oboe())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_OpenSLES())
            addIfNotNull(list, juce.AudioIODeviceType.createAudioIODeviceType_Android())
        End Sub
    End Class

    Sub display_device_probe(deviceManager As TestAudioDeviceManager)
        Console.WriteLine("Audio device probe results:")
        Dim device_count As Integer = 0
        For Each t As var In deviceManager.getAvailableDeviceTypes()
            Dim typeString As juce.String
            typeString << "Type " & t.getTypeName() & ":"
            Console.WriteLine(typeString)
            Dim deviceNames = t.getDeviceNames()
            device_count += deviceNames.size()
            For Each deviceName As var In deviceNames
                Console.WriteLine("  - " & deviceName)
            Next
        Next
        Console.WriteLine("Discovered " & device_count & " total audio devices.")

        Dim curType = deviceManager.getCurrentDeviceTypeObject()
        Dim curDevice = deviceManager.getCurrentAudioDevice()

        Console.Write("Current audio device: ")
        If curType Is Nothing OrElse curDevice Is Nothing Then
            Console.WriteLine("<none>")
        Else
            Console.WriteLine(curType.getTypeName() & " - " & curDevice.getName().quoted())
            Console.WriteLine("Sample rate: " & curDevice.getCurrentSampleRate() & " Hz")
            Console.WriteLine("Block size: " & curDevice.getCurrentBufferSizeSamples() & " samples")
            Console.WriteLine("Bit depth: " & curDevice.getCurrentBitDepth())
        End If
    End Sub

    Sub Main()
        Console.WriteLine("Initialising audio playback device.")
        Dim deviceManager As New TestAudioDeviceManager()

        Dim error = deviceManager.initialise(0, 2, Nothing, True)

        If error.isNotEmpty() Then
            Console.WriteLine("Error on initialise(): " & error.toStdString())
            Environment.Exit(-1)
        End If

        display_device_probe(deviceManager)

        Thread.Sleep(1000)

        Dim pause As Integer = 2
        Dim start = DateTime.Now

        Console.WriteLine("You should hear five test tones, precisely " & pause & " second" & If(pause > 1, "s", "") & " apart.")

        For s As Integer = 1 To 5
            Console.Write(s)
            If s < 5 Then
                Console.Write("... ")
            Else
                Console.Write(".")
            End If
            deviceManager.playTestSound()
            Thread.Sleep((DateTime.Now - start).Add(New TimeSpan(0, 0, pause)))
        Next

        Console.WriteLine("Demo complete. Shutting down device manager.")

        deviceManager.closeAudioDevice()
        deviceManager.removeAllChangeListeners()
        deviceManager.dispatchPendingMessages()
    End Sub

End Module


'#include <iostream>
'#include <thread>
'#include <chrono>

'// Avoid an implicit (And deprecated) 'using namespace juce;'
'#ifndef DONT_SET_USING_JUCE_NAMESPACE
'    #define DONT_SET_USING_JUCE_NAMESPACE 1
'#End If
'#include "OpenShotAudio.h"

'// Subclass the AudioDeviceManager so we can skip WASAPI devices on Windows
'Class TestAudioDeviceManager : Public juce : AudioDeviceManager {
'Public
'    Static void addIfNotNull (
'        juce:OwnedArray<juce:AudioIODeviceType>& list,
'        juce:AudioIODeviceType* const device)
'    {
'        If (device!= nullptr)
'            list.add (device);
'    }

'    void createAudioDeviceTypes(juce: OwnedArray<juce:AudioIODeviceType>& list) override
'    {
'        /*
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_WASAPI (false));
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_WASAPI (true));
'        */
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_DirectSound());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_ASIO());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_CoreAudio());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_iOSAudio());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_Bela());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_ALSA());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_JACK());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_Oboe());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_OpenSLES());
'        addIfNotNull (list, juce:AudioIODeviceType:createAudioIODeviceType_Android());
'    }
'};


'void display_device_probe(TestAudioDeviceManager& deviceManager) {
'    std:cout << "Audio device probe results:\n";
'    int device_count = 0;
'    For (const auto& t : deviceManager.getAvailableDeviceTypes()) {
'        juce: String typeString;
'        typeString << "Type " << t->getTypeName() << ":";
'        std:cout << typeString << std:endl;
'        auto deviceNames = t -> getDeviceNames();
'        device_count += deviceNames.size();
'        For (const auto deviceName : deviceNames) {
'            std:cout << "  - " << deviceName << std:endl;
'        }
'    }
'    std:cout << "Discovered " << device_count << " total audio devices.\n\n";

'    Const auto* curType = deviceManager.getCurrentDeviceTypeObject();
'    auto* curDevice = deviceManager.getCurrentAudioDevice();

'    std:cout << "Current audio device: ";
'    If (curType == nullptr || curDevice == nullptr) {
'        std:cout << "<none>\n";
'    } else {
'        std:cout << curType->getTypeName()
'                  << " - " << curDevice->getName().quoted() << '\n';
'        std:cout << "Sample rate: "
'                  << curDevice->getCurrentSampleRate() << " Hz\n";
'        std:cout << "Block size: "
'                  << curDevice->getCurrentBufferSizeSamples() << " samples\n";
'        std:cout << "Bit depth: "
'                  << curDevice->getCurrentBitDepth() << '\n';
'    }
'}


'int main(int argc, char* argv[])
'{
'    juce:ignoreUnused (argc, argv);

'    // Initialize default audio device
'    std:cout << "Initialising audio playback device.\n";
'    TestAudioDeviceManager deviceManager;

'    auto error = deviceManager.initialise (
'        0,        // numInputChannelsNeeded
'        2,        // numOutputChannelsNeeded
'        nullptr,  // savedState
'        true      // selectDefaultDeviceOnFailure
'    );

'    // Output error (if any)
'    If (error.isNotEmpty()) {
'        std:cout << "Error on initialise(): " << error.toStdString() << std:endl;
'        Exit(-1);
'    }

'    // Show detected audio devices
'    display_device_probe(deviceManager);

'    // Pause to take all that in
'    std:this_thread:sleep_for(std:chrono:seconds(1));

'    // Play test sound

'    Const int pause(2);
'    Using stride = std : chrono:duration<double, std:ratio<pause, 1>>;

'    std:cout << "\nYou should hear five test tones, precisely "
'              << pause << " second" << (pause > 1 ? "s" : "")
'              << " apart.\n";

'    auto start = std : chrono:steady_clock:now();

'    For (auto s = static_cast < stride > (1); s < static_cast<stride>(6); ++s) {
'        std:cout << s.count() << (s.count() < 5 ? "... " : ".") << std:flush;
'        deviceManager.playTestSound();
'        std:this_thread:sleep_until(start + s);
'    }

'    std:cout << "\nDemo complete. Shutting down device manager.\n";

'    // Stop audio devices
'    deviceManager.closeAudioDevice();
'    deviceManager.removeAllChangeListeners();
'    deviceManager.dispatchPendingMessages();

'    Return 0;
'}