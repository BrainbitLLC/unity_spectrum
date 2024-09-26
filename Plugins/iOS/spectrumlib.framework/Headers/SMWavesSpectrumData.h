#ifndef SMWavesSpectrumData_h
#define SMWavesSpectrumData_h

#include "Foundation/Foundation.h"

@interface SMWavesSpectrumData : NSObject

@property (nonatomic) double delta_raw, theta_raw, alpha_raw, beta_raw, gamma_raw;
@property (nonatomic) double delta_rel, theta_rel, alpha_rel, beta_rel, gamma_rel; // relative waves values

-(id) initWithDeltaRaw:(double) deltaRaw andThetaRaw: (double) thetaRaw andAlphaRaw:(double) alphaRaw andBetaRaw:(double) betaRaw andGammaRaw:(double) gammaRaw andDeltaRel:(double) deltaRel andThetaRel: (double) thetaRel andAlphaRel:(double) alphaRel andBetaRel:(double) betaRel andGammaRel:(double) gammaRel;
@end


#endif /* SMWavesSpectrumData_h */
