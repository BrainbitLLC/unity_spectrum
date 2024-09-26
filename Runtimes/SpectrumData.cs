using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NeuroTech.Spectrum
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeRawSpectrumData
    {
        public int AllBinsNums;
        public IntPtr AllBinsValues;
        public double TotalRawPow;
    }

    public struct RawSpectrumData
    {
        public double[] AllBinsValues;
        public double TotalRawPow;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct WavesSpectrumData
    {
        public double DeltaRaw, ThetaRaw, Alpha_Raw, BetaRaw, GammaRaw;  // absolute waves values
        public double DeltaRel, ThetaRel, Alpha_Rel, BetaRel, GammaRel;  // relative waves values
    }
}
