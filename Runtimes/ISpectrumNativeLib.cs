using NativeLibSourceGeneratorShared;
using System;
using System.Runtime.InteropServices;

namespace NeuroTech.Spectrum
{
    public static class LibNamePropvider
    {
        public const string LibName = "spectrumlib";
        public const string LibNameiOS = "__Internal";
        public const string LibNameWin32= LibName + "-x86";
        public const string LibNameWin64 = LibName + "-x64";
        public const string LibNameWinArm = LibName + "-arm";
        public const string LibNameWinArm64 = LibName + "-arm64";
    }

    [NativeLib(LibNamePropvider.LibName, NativePlatformType.Default)]
    [NativeLib(LibNamePropvider.LibNameWin32, NativePlatformType.WinX86)]
    [NativeLib(LibNamePropvider.LibNameWin64, NativePlatformType.WinX64)]
    [NativeLib(LibNamePropvider.LibNameWinArm, NativePlatformType.WinArm)]
    [NativeLib(LibNamePropvider.LibNameWinArm64, NativePlatformType.WinArm64)]
    [NativeLib(LibNamePropvider.LibNameiOS, NativePlatformType.iOS)]
    [NativeLib(LibNamePropvider.LibName, NativePlatformType.AndroidARMv7, 
        NativePlatformType.AndroidARMv8,
        NativePlatformType.AndroidX86, 
        NativePlatformType.AndroidX64, 
        NativePlatformType.OSX,
        NativePlatformType.LinuxX64,
        NativePlatformType.LinuxX86)]
    public interface ISpectrumNativeLib
    {
        IntPtr createSpectrumMath(int sampl_rate, int fft_window, int process_win_freq);
        void freeSpectrumMath(IntPtr ptr);
        void SpectrumMathInitParams(IntPtr ptr, int up_border_frequency, bool normalize_spect_by_bandwidth);
        void SpectrumMathSetFFTWinLengthAndProccessFreq(IntPtr ptr, int fft_win_length, int process_win_freq);
        void SpectrumMathSetWavesCoeffs(IntPtr spectrumMathPtr, double d_coef, double t_coef, double a_coef, double b_coef, double g_coef);
        void SpectrumMathSetHanningWinSpect(IntPtr spectrumMathPtr);
        void SpectrumMathSetHammingWinSpect(IntPtr spectrumMathPtr);
        void SpectrumMathPushData(IntPtr spectrumMathPtr, [In,Out] double[] samples, int sampleCount);
    	void SpectrumMathProcessData(IntPtr spectrumMathPtr);
        void SpectrumMathComputeSpectrum(IntPtr spectrumMathPtr, [In,Out] double[] vals_arr, int arr_size);
        double SpectrumMathGetFFTBinsFor1Hz(IntPtr spectrumMathPtr);
        int SpectrumMathGetFFTWindow(IntPtr spectrumMathPtr);
        void SpectrumMathReadRawSpectrumInfo(IntPtr spectrumMathPtr, ref NativeRawSpectrumData raw_spect_data);
        void SpectrumMathReadWavesSpectrumInfo(IntPtr spectrumMathPtr, ref WavesSpectrumData waves_spect_data);
        uint SpectrumMathReadSpectrumArrSize(IntPtr spectrumMathPtr);
        void SpectrumMathReadRawSpectrumInfoArr(IntPtr spectrumMathPtr, [In,Out] NativeRawSpectrumData[] raw_spect_data_arr, ref uint arr_size);
        void SpectrumMathReadWavesSpectrumInfoArr(IntPtr spectrumMathPtr, [In,Out] WavesSpectrumData[] waves_spect_data_arr, ref uint arr_size);
        void SpectrumMathSetNewSampleSize(IntPtr spectrumMathPtr);
        void SpectrumMathClearData(IntPtr spectrumMathPtr);
        void SpectrumMathReleaseNativeArray(IntPtr arrayPtr);
        void SpectrumMathSetSquaredSpect(IntPtr spectrumMathPtr, bool fl);
    }
}
