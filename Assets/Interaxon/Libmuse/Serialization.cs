﻿using Newtonsoft.Json;

using System.Collections.Generic;

namespace Interaxon.Libmuse
{
    public class MuseConnectionState
    {
        public ConnectionState PreviousConnectionState { get; set; }

        public ConnectionState CurrentConnectionState { get; set; }

        public static MuseConnectionState FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MuseConnectionState>(json);
        }
    }

    public class LogPacket
    {
        public static LogPacket FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LogPacket>(json);
        }

        [JsonProperty("severity")]
        public Severity Severity { get; private set; }

        [JsonProperty("raw")]
        public bool Raw { get; private set; }

        [JsonProperty("tag")]
        public string Tag { get; private set; }

        [JsonProperty("timestamp")]
        public double Timestamp { get; private set; }

        [JsonProperty("message")]
        public string Message { get; private set; }
    }

    public class MuseConnectionPacket
    {
        public static MuseConnectionPacket FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MuseConnectionPacket>(json);
        }

        [JsonProperty("currentConnectionState")]
        public ConnectionState CurrentConnectionState { get; private set; }

        [JsonProperty("previousConnectionState")]
        public ConnectionState PreviousConnectionState { get; private set; }

        [JsonProperty("bluetoothMac")]
        public string BluetoothMac { get; private set; }
    }

    public class MuseDataPacket
    {
        public static MuseDataPacket FromNative(MuseDataPacketType packetType, double[] values, long timestamp, string macAddress)
        {
            return new MuseDataPacket
            {
                PacketType = packetType,
                Values = values,
                ValuesSize = values.Length,
                BluetoothMac = macAddress,
                Timestamp = timestamp
            };
        }

        [JsonProperty("packetType")]
        public MuseDataPacketType PacketType { get; private set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; private set; }

        [JsonProperty("values")]
        public double[] Values { get; private set; }

        [JsonProperty("valuesSize")]
        public long ValuesSize { get; private set; }

        [JsonProperty("bluetoothMac")]
        public string BluetoothMac { get; private set; }
    }

    public class MuseArtifactPacket
    {
        public static MuseArtifactPacket FromNative(double[] values, long timestamp, string macAddress)
        {
            return new MuseArtifactPacket
            {
                HeadbandOn = !values[0].Equals(0),
                Blink = !values[1].Equals(0),
                JawClench = !values[2].Equals(0),
                BluetoothMac = macAddress,
                Timestamp = timestamp
            };
        }

        [JsonProperty("headbandOn")]
        public bool HeadbandOn { get; private set; }

        [JsonProperty("blink")]
        public bool Blink { get; private set; }

        [JsonProperty("jawClench")]
        public bool JawClench { get; private set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; private set; }

        [JsonProperty("bluetoothMac")]
        public string BluetoothMac { get; private set; }
    }

    public class MuseConfiguration
    {
        public static MuseConfiguration FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MuseConfiguration>(json);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        [JsonProperty("preset")]
        public MusePreset Preset { get; private set; }

        [JsonProperty("headbandName")]
        public string HeadbandName { get; private set; }

        [JsonProperty("microcontrollerId")]
        public string MicrocontrollerId { get; private set; }

        [JsonProperty("eegChannelCount")]
        public int EegChannelCount { get; private set; }

        [JsonProperty("afeGain")]
        public int AfeGain { get; private set; }

        [JsonProperty("downsampleRate")]
        public int DownsampleRate { get; private set; }

        [JsonProperty("seroutMode")]
        public int SeroutMode { get; private set; }

        [JsonProperty("outputFrequency")]
        public int OutputFrequency { get; private set; }

        [JsonProperty("adcFrequency")]
        public int AdcFrequency { get; private set; }

        [JsonProperty("notchFilterEnabled")]
        public bool NotchFilterEnabled { get; private set; }

        [JsonProperty("notchFilter")]
        public NotchFrequency NotchFilter { get; private set; }

        [JsonProperty("accelerometerSampleFrequency")]
        public int AccelerometerSampleFrequency { get; private set; }

        [JsonProperty("batteryDataEnabled")]
        public bool BatteryDataEnabled { get; private set; }

        [JsonProperty("drlRefEnabled")]
        public bool DrlRefEnabled { get; private set; }

        [JsonProperty("drlRefFrequency")]
        public int DrlRefFrequency { get; set; }

        [JsonProperty("batteryPercentRemaining")]
        public double BatteryPercentRemaining { get; private set; }

        [JsonProperty("bluetoothMac")]
        public string BluetoothMac { get; private set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; private set; }

        [JsonProperty("headsetSerialNumber")]
        public string HeadsetSerialNumber { get; set; }

        [JsonProperty("model")]
        public MuseModel Model { get; private set; }

        [JsonProperty("nonce")]
        public string LicenseNonce { get; set; }
    }

    public class MuseVersion
    {
        public static MuseVersion FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MuseVersion>(json);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        [JsonProperty("runningState")]
        public string RunningState { get; private set; }

        [JsonProperty("hardwareVersion")]
        public string HardwareVersion { get; private set; }

        [JsonProperty("bspVersion")]
        public string BspVersion { get; private set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; private set; }

        [JsonProperty("bootloaderVersion")]
        public string BootloaderVersion { get; private set; }

        [JsonProperty("firmwareBuildNumber")]
        public string FirmwareBuildNumber { get; private set; }

        [JsonProperty("firmwareType")]
        public string FirmwareType { get; private set; }

        [JsonProperty("protocolVersion")]
        public int ProtocolVersion { get; private set; }
    }

    public class MuseError
    {
        public static MuseError FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MuseError>(json);
        }

        [JsonProperty("type")]
        public ErrorType Type { get; private set; }

        [JsonProperty("code")]
        public int Code { get; private set; }

        [JsonProperty("info")]
        public string Info { get; private set; }

        [JsonProperty("bluetoothMac")]
        public string BluetoothMac { get; private set; }
    }

    public class AnnotationData
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("format")]
        public AnnotationFormat Format { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DspData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("floatArray")]
        public double[] FloatArray { get; set; }

        [JsonProperty("intArray")]
        public long[] IntArray { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ComputingDeviceConfiguration
    {
        [JsonProperty("osType")]
        public string OsType { get; set; }

        [JsonProperty("osVersion")]
        public string OsVersion { get; set; }

        [JsonProperty("hardwareModelName")]
        public string HardwareModelName { get; set; }

        [JsonProperty("hardwareModelId")]
        public string HardwareModelId { get; set; }

        [JsonProperty("processorName")]
        public string ProcessorName { get; set; }

        [JsonProperty("processorSpeed")]
        public string ProcessorSpeed { get; set; }

        [JsonProperty("numberOfProcessors")]
        public int ProcessorCount { get; set; }

        [JsonProperty("memorySize")]
        public string MemorySize { get; set; }

        [JsonProperty("bluetoothVersion")]
        public string BluetoothVersion { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("timeZoneOffsetSeconds")]
        public int TimeZoneOffsetSeconds { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
