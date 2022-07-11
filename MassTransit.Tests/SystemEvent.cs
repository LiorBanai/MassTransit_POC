using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Tests
{
    public enum SystemEventType
    {
        Dummy = 0,

        PAQConnectionError = 4,  // obsolete
        PAQConnectionOk = 5,     // obsolete
        PAQHardwareConnectionError = 6,
        PAQHardwareConnectionOk = 7,
        ECGCycleDescription = 9,
        NetworkAvailabilityOn = 10,   // obsolete
        NetworkAvailabilityOff = 11,  // obsolete
        ECGBodyLeadConnected = 12,    // obsolete
        ECGBodyLeadDisconnected = 13, // obsolete
        FreeSpace = 14,               // obsolete
        General = 15,
        HealthCheck = 16,             // obsolete

        PAQConnection = 17, // checked
        PAQHardwareConnection = 18, // checked
        NetworkAvailability = 19, // checked
        ECGBodyLeadConnection = 20,
        NavigationAccuracy = 21,
        FreeSpaceWarning = 22, // checked
        FreeSpaceError = 23, // checked
        Database = 24,
        ElectrodesServiceStart = 25,
        ElectrodesServiceStop = 26,
        EcgServiceStart = 27,
        EcgServiceStop = 28,
        PythonServiceStart = 29,
        PythonServiceStop = 30,
        LabelKeypoint = 31,
        TagAdded = 32,
        TagDeleted = 33,
        ECGFullCycleDescription = 34,
        MeansServiceError = 35,
        PunctureDetection = 36,
        StartRecording = 37,
        StopRecording = 38,
        MeansRawDataDebugging = 39,
        MeansInputDataDebugging = 40,
        EcgLeadOffEvent_V1_limb = 41,
        EcgLeadOffEvent_LL_limb = 42,
        EcgLeadOffEvent_RA_limb = 43,
        EcgLeadOffEvent_LA_limb = 44,
        ProtocolValidationFailed = 45,
        KalpaEitStatus = 46,
        KalpaEcgStatus = 47,
        ProcedureComment = 48,
        GeolocationEvent = 49,
        KcmMeansOutput = 50,
        UserEvent = 51,
        UserTag = 52,
        SetBITMode = 53,
        SetEcgTxChannels = 54,
        BitEitResultsEvent = 55,
        BitEcgResultsEvent = 56,
        SetWorkingModeECG = 57,
        ECGProcessingService = 58,
        UserNotificationMessage = 59,
        MeshExclusionSphereAdded = 60,
        MeshExclusionSphereReset = 61,
        MeansInputOutputData = 62,
        OfflineEcgData = 63,
        ServicesInitialization = 64,
        MeansProcessingResult = 65,
        CaraBookmarks = 66,
        CaraBaseline = 77,

        // Algorithm events - 
        PythonBeginEvents = 99,
        NewVisualModelReady = PythonBeginEvents + 1,
        NewV2RModelReady = PythonBeginEvents + 2,
        NewMeshReady = PythonBeginEvents + 3,

        MissAlignment = PythonBeginEvents + 5,
        SheathDetected = PythonBeginEvents + 6,
        LeakAnalysis = PythonBeginEvents + 7,
        BreathAndHeartRate = PythonBeginEvents + 8,
        WatchmanStateAnalysis = PythonBeginEvents + 9,
        NewBinningInfoReady = PythonBeginEvents + 10,
        ContourAnalysis = PythonBeginEvents + 11,
        NewActiveVolumeReady = PythonBeginEvents + 12,
        NewPotentiometerLMapping = PythonBeginEvents + 13,
        PotentiometerStabilizationEnded = PythonBeginEvents + 14,
        PotentiometerStatus = PythonBeginEvents + 15,
        NewCineReady = PythonBeginEvents + 16,
        DeploymentPointPosition = PythonBeginEvents + 17,
        NewECGDataFromDB = PythonBeginEvents + 18,
        ECGAnalysisFrame = PythonBeginEvents + 19,
        ECGLeadOff = PythonBeginEvents + 20,
        AFResultEvent = PythonBeginEvents + 21,
        PythonEndEvents = 198,

        // KX & Kalpa HW Errors OR NOrav 
        HWBeginEvents = 199,
        Saturation = HWBeginEvents + 1,
        PinConnectEvent = HWBeginEvents + 2,
        HardwareFailEvent = HWBeginEvents + 3,
        TemperatureFailureEvent = HWBeginEvents + 4,
        TaxometerFailureEvent = HWBeginEvents + 5,
        PowerConsumptionEvent = HWBeginEvents + 6,
        CurrentOverStandartEvent = HWBeginEvents + 7,
        SystemVoltageFailureEvent = HWBeginEvents + 8,
        GeneralHardwareErrorEvent = 208,
        DCLeakageDetectionEvent = 209,
        DCLeakageDetectionLogReady = 210,
        PinBoxExternalEvent = 211,
        EcgLeadOffEvent = 212,
        TestModeEventChangedEvent = 213,
        ECGAcquisitionDeviceConnection = 214,
        EcgBatteryEvent = 215,
        NoravSamplingIssue = 216
    }
    [DebuggerDisplay("Event Type={SystemEventType.ToString()}, TimeStamp = {TimeStamp}. Is Error: {IsError}")]
    public class SystemEvent : IEquatable<SystemEvent>
    {
        public SystemEventType SystemEventType { get; set; }
        public long TimeStamp { get; set; }
        public string EventData { get; set; }
        public bool IsError { get; set; }
        /// <summary>
        ///Used by Angular
        /// </summary>
        public string SystemEventName => Enum.GetName(typeof(SystemEventType), SystemEventType);
        public SystemEvent()
        {
            EventData = string.Empty;
        }

        public SystemEvent(SystemEventType systemEventType, long timeStamp, string eventData, bool isError = false)
        {
            SystemEventType = systemEventType;
            TimeStamp = timeStamp;
            EventData = eventData;
            IsError = isError;
        }
    
        public bool Equals(SystemEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SystemEventType == other.SystemEventType && TimeStamp == other.TimeStamp &&
                   EventData == other.EventData && IsError == other.IsError;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SystemEvent)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)SystemEventType;
                hashCode = (hashCode * 397) ^ TimeStamp.GetHashCode();
                hashCode = (hashCode * 397) ^ (EventData != null ? EventData.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() => $"{nameof(SystemEventType)}: {SystemEventType}, {nameof(EventData)}: {EventData}, {nameof(IsError)}: {IsError}. {nameof(TimeStamp)}: {TimeStamp}";
    }
}
