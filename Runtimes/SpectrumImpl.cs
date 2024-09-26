using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NeuroTech.Spectrum
{
  
    public class SpectrumMath : IDisposable
    {

        private IntPtr _nativePtr;

        public SpectrumMath(int sampleRate, int fftWindow, int processWinFreq)
        {
            _nativePtr = SpectrumNativeLib.Inst.createSpectrumMath(sampleRate, fftWindow, processWinFreq);
        }

        public void InitParams(int upBorderFrequency, bool normalizeSpectByBandwidth)
        {
            SpectrumNativeLib.Inst.SpectrumMathInitParams(_nativePtr, upBorderFrequency, normalizeSpectByBandwidth);
        }
        public void SetWavesCoeffs(double dCoef, double tCoef, double aCoef, double bCoef, double gCoef)
        {
            SpectrumNativeLib.Inst.SpectrumMathSetWavesCoeffs(_nativePtr, dCoef, tCoef, aCoef, bCoef, gCoef);
        }
        public void SetHanningWinSpect()
        {
            SpectrumNativeLib.Inst.SpectrumMathSetHanningWinSpect(_nativePtr);
        }
        public void SetHammingWinSpect()
        {
            SpectrumNativeLib.Inst.SpectrumMathSetHammingWinSpect(_nativePtr);
        }
        public void SetSquaredSpect(bool fl)
        {
            SpectrumNativeLib.Inst.SpectrumMathSetSquaredSpect(_nativePtr, fl);
        }
        public void SetFFTWinLengthAndProccessFreq(int fftWindow, int processWinFreq)
        {
            SpectrumNativeLib.Inst.SpectrumMathSetFFTWinLengthAndProccessFreq(_nativePtr, fftWindow, processWinFreq);
        }
        public void PushAndProcessData(double[] samples)
        {
            SpectrumNativeLib.Inst.SpectrumMathPushData(_nativePtr, samples, samples.Length);
            SpectrumNativeLib.Inst.SpectrumMathProcessData(_nativePtr);
        }
        public void ComputeSpectrum(double[] valsArr)
        {
            SpectrumNativeLib.Inst.SpectrumMathComputeSpectrum(_nativePtr, valsArr, valsArr.Length);
        }
        public double GetFFTBinsFor1Hz()
        {
            return SpectrumNativeLib.Inst.SpectrumMathGetFFTBinsFor1Hz(_nativePtr);
        }
        public int GetFFTWindow()
        {
            return SpectrumNativeLib.Inst.SpectrumMathGetFFTWindow(_nativePtr);
        }
        public RawSpectrumData ReadRawSpectrumInfo()
        {
            NativeRawSpectrumData nativeData = new NativeRawSpectrumData();
            SpectrumNativeLib.Inst.SpectrumMathReadRawSpectrumInfo(_nativePtr, ref nativeData);

            var binValues = new double[nativeData.AllBinsNums];
            Marshal.Copy(nativeData.AllBinsValues, binValues, 0, binValues.Length);

            SpectrumNativeLib.Inst.SpectrumMathReleaseNativeArray(nativeData.AllBinsValues);
            var resData = new RawSpectrumData
            {
                AllBinsValues = binValues,
                TotalRawPow = nativeData.TotalRawPow
            };
            return resData;
        }
        public WavesSpectrumData ReadWavesSpectrumInfo()
        {
            WavesSpectrumData resData = new WavesSpectrumData();
            SpectrumNativeLib.Inst.SpectrumMathReadWavesSpectrumInfo(_nativePtr, ref resData);
            return resData;
        }
        public RawSpectrumData[] ReadRawSpectrumInfoArr()
        {
            var rawArrSize = SpectrumNativeLib.Inst.SpectrumMathReadSpectrumArrSize(_nativePtr);
            //if (rawArrSize == 0)
            //	return new RawSpectrumData[0];

            NativeRawSpectrumData[] nativeRawSpectrumDatas = new NativeRawSpectrumData[rawArrSize];
            SpectrumNativeLib.Inst.SpectrumMathReadRawSpectrumInfoArr(_nativePtr, nativeRawSpectrumDatas, ref rawArrSize);

            RawSpectrumData[] rawSpectrumDatas = new RawSpectrumData[rawArrSize];
            for (int i = 0; i < rawArrSize; i++)
            {
                var nativeBinSize = nativeRawSpectrumDatas[i].AllBinsNums;
                var nativeBinValPtr = nativeRawSpectrumDatas[i].AllBinsValues;

                double[] values = new double[nativeBinSize];
                Marshal.Copy(nativeBinValPtr, values, 0, nativeBinSize);
                rawSpectrumDatas[i] = new RawSpectrumData
                {
                    AllBinsValues = values,
                    TotalRawPow = nativeRawSpectrumDatas[i].TotalRawPow
                };
            }

            for (int i = 0; i < rawArrSize; i++)
                SpectrumNativeLib.Inst.SpectrumMathReleaseNativeArray(nativeRawSpectrumDatas[i].AllBinsValues);

            return rawSpectrumDatas;
        }
        public WavesSpectrumData[] ReadWavesSpectrumInfoArr()
        {
            var arrSize = SpectrumNativeLib.Inst.SpectrumMathReadSpectrumArrSize(_nativePtr);
            WavesSpectrumData[] resData = new WavesSpectrumData[arrSize];
            SpectrumNativeLib.Inst.SpectrumMathReadWavesSpectrumInfoArr(_nativePtr, resData, ref arrSize);
            return resData;
        }
        public void SetNewSampleSize()
        {
            SpectrumNativeLib.Inst.SpectrumMathSetNewSampleSize(_nativePtr);
        }
        public void ClearData()
        {
            SpectrumNativeLib.Inst.SpectrumMathClearData(_nativePtr);
        }

        public void Dispose()
        {
            if (_nativePtr != IntPtr.Zero)
            {
                SpectrumNativeLib.Inst.freeSpectrumMath(_nativePtr);
                _nativePtr = IntPtr.Zero;
            }
        }
    }
}