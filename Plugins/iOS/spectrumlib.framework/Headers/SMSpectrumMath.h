#ifndef SMSpectrumMath_h
#define SMSpectrumMath_h

#import <Foundation/Foundation.h>
#import <Foundation/NSArray.h>
#include "common_api_spect.h"
#include "SMWavesSpectrumData.h"
#include "SMRawSpectrumData.h"

@interface SMSpectrumMath : NSObject{
    SpectrumMath* math; 
}

-(id)  initWithSampleRate :(int) sampl_rate andFftWindow: (int) fft_window andProcessWinFreq: (int) process_win_freq;
-(void) initParamsWithUpBorderFreq:(int) up_border_frequency andNormilize: (bool) normalize_spect_by_bandwidth;
-(void) setWavesCoeffsWithDelta: (double) d_coef andTheta:(double) t_coef andAlpha:(double) a_coef andBeta: (double) b_coef andGamma: (double) g_coef;
-(void) setHanningWinSpect;
-(void) setHammingWinSpect;
-(void) setSquaredSpect: (bool) fl;
-(void) pushAndProcessData: (NSArray<NSNumber*>*) data;
-(void) computeSpectrum:(NSArray<NSNumber*>*) data;
-(double)  getFFTBinsFor1Hz;
-(SMRawSpectrumData*) readRawSpectrumInfo;
-(SMWavesSpectrumData*) readWavesSpectrumInfo;
-(uint32_t)  readSpectrumArrSize;
-(NSArray<SMRawSpectrumData*>*) readRawSpectrumInfoArr;
-(NSArray<SMWavesSpectrumData*>*) readWavesSpectrumInfoArr;
-(void) setNewSampleSize;
-(void) clearData;
@end

#endif /* SMSpectrumMath_h */
