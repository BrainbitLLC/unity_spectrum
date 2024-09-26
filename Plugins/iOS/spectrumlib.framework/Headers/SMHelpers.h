#import <Foundation/Foundation.h>
#import "common_api_spect.h"
#import "SMWavesSpectrumData.h"
#import "SMRawSpectrumData.h"


#ifndef SMHelpers_h
#define SMHelpers_h

SMWavesSpectrumData* wavesSpectrumFromNative(const WavesSpectrumData& nativeData);
SMRawSpectrumData* rawSpectrumFromNative(const RawSpectrumData& nativeData);

#endif /* SMHelpers_h */
