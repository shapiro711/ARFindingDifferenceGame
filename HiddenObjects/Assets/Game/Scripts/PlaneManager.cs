using System.Timers;
using UnityEngine;
using Vuforia;

namespace Pump.HiddenObjects
{
    public class PlaneManager : MonoBehaviour
    {
        /*
        private const string UnsupportedDeviceTitle = "Unsupported Device";
        private const string UnsupportedDeviceBody =
            "This device has failed to start the Positional Device Tracker. " +
            "Please check the list of supported Ground Plane devices on our site: " +
            "\n\nhttps://library.vuforia.com/articles/Solution/ground-plane-supported-devices.html";

        static TrackableBehaviour.Status StatusCached = TrackableBehaviour.Status.NO_POSE;
        static TrackableBehaviour.StatusInfo StatusInfoCached = TrackableBehaviour.StatusInfo.UNKNOWN;

        private PositionalDeviceTracker positionalDeviceTracker;
        private SmartTerrain smartTerrain;
        private StateManager stateManager;

        private Timer timer;
        private bool timerFinished;

        private void Start()
        {
            VuforiaARController.Instance.RegisterVuforiaStartedCallback(this.OnVuforiaStarted);
            VuforiaARController.Instance.RegisterOnPauseCallback(this.OnVuforiaPaused);
            DeviceTrackerARController.Instance.RegisterTrackerStartedCallback(this.OnTrackerStarted);
            DeviceTrackerARController.Instance.RegisterDevicePoseStatusChangedCallback(this.OnDevicePoseStatusChanged);

            this.timer = new Timer(10000);
            this.timer.Elapsed += this.TimerFinished;
            this.timer.AutoReset = false;
        }

        private void Update()
        {
            // The timer runs on a separate thread and we need to ResetTrackers on the main thread.
            if (this.timerFinished)
            {
                this.ResetTrackers();
                this.timerFinished = false;
            }
        }

        void OnDestroy()
        {
            VuforiaARController.Instance.UnregisterVuforiaStartedCallback(this.OnVuforiaStarted);
            VuforiaARController.Instance.UnregisterOnPauseCallback(this.OnVuforiaPaused);
            DeviceTrackerARController.Instance.UnregisterTrackerStartedCallback(this.OnTrackerStarted);
            DeviceTrackerARController.Instance.UnregisterDevicePoseStatusChangedCallback(this.OnDevicePoseStatusChanged);
        }

        public void ResetTrackers()
        {
            Debug.Log("ResetTrackers() called.");

            this.smartTerrain = TrackerManager.Instance.GetTracker<SmartTerrain>();
            this.positionalDeviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();

            // Stop and restart trackers
            this.smartTerrain.Stop(); // stop SmartTerrain tracker before PositionalDeviceTracker
            this.positionalDeviceTracker.Reset();
            this.smartTerrain.Start(); // start SmartTerrain tracker after PositionalDeviceTracker
        }

        private void TimerFinished(System.Object source, ElapsedEventArgs e)
        {
            this.timerFinished = true;
        }

        private void OnVuforiaStarted()
        {
            UIControl.Instance.Log = "OnVuforiaStarted() called.";
            
            this.stateManager = TrackerManager.Instance.GetStateManager();

            this.positionalDeviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
            this.smartTerrain = TrackerManager.Instance.GetTracker<SmartTerrain>();

            if (this.positionalDeviceTracker != null && this.smartTerrain != null)
            {
                if (!this.positionalDeviceTracker.IsActive)
                {
                    UIControl.Instance.Log = "The Ground Plane feature requires the Device Tracker to be started. " +
                                   "Please enable it in the Vuforia Configuration or start it at runtime through the scripting API.";
                    return;
                }

                if (this.positionalDeviceTracker.IsActive && !this.smartTerrain.IsActive)
                {
                    this.smartTerrain.Start();
                }
            }
            else
            {
                if (this.positionalDeviceTracker == null)
                    UIControl.Instance.Log = "PositionalDeviceTracker returned null. GroundPlane not supported on this device.";
                if (this.smartTerrain == null)
                    UIControl.Instance.Log = "SmartTerrain returned null. GroundPlane not supported on this device.";

                MessageBox.DisplayMessageBox(UnsupportedDeviceTitle, UnsupportedDeviceBody, false, null);
            }
        }

        private void OnVuforiaPaused(bool paused)
        {
            UIControl.Instance.Log = "OnVuforiaPaused(" + paused.ToString() + ") called.";
        }

        private void OnTrackerStarted()
        {
            UIControl.Instance.Log = "PlaneManager.OnTrackerStarted() called.";

            this.positionalDeviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
            this.smartTerrain = TrackerManager.Instance.GetTracker<SmartTerrain>();

            if (this.positionalDeviceTracker != null && this.smartTerrain != null)
            {
                if (!this.positionalDeviceTracker.IsActive)
                {
                    UIControl.Instance.Log = "The Ground Plane feature requires the Device Tracker to be started. " +
                                   "Please enable it in the Vuforia Configuration or start it at runtime through the scripting API.";
                    return;
                }

                if (!this.smartTerrain.IsActive)
                    this.smartTerrain.Start();

                UIControl.Instance.Log = "PositionalDeviceTracker is Active?: " + this.positionalDeviceTracker.IsActive +
                          "\nSmartTerrain Tracker is Active?: " + this.smartTerrain.IsActive;
            }
        }

        private void OnDevicePoseStatusChanged(TrackableBehaviour.Status status, TrackableBehaviour.StatusInfo statusInfo)
        {
            UIControl.Instance.Log = "PlaneManager.OnDevicePoseStatusChanged(" + status + ", " + statusInfo + ")";

            StatusCached = status;
            StatusInfoCached = statusInfo;

            if (statusInfo != TrackableBehaviour.StatusInfo.RELOCALIZING && this.timer.Enabled)
            {
                this.timer.Stop();
            }

            switch (statusInfo)
            {
                case TrackableBehaviour.StatusInfo.NORMAL:
                    break;
                case TrackableBehaviour.StatusInfo.UNKNOWN:
                    break;
                case TrackableBehaviour.StatusInfo.INITIALIZING:
                    break;
                case TrackableBehaviour.StatusInfo.EXCESSIVE_MOTION:
                    break;
                case TrackableBehaviour.StatusInfo.INSUFFICIENT_FEATURES:
                    break;
                case TrackableBehaviour.StatusInfo.INSUFFICIENT_LIGHT:
                    break;
                case TrackableBehaviour.StatusInfo.RELOCALIZING:
                    if (!this.timer.Enabled)
                    {
                        this.timer.Start();
                    }
                    break;
                default:
                    break;
            }
        */
    } 
}
