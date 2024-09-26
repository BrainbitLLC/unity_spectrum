#ifndef SMRawSpectrumData_h
#define SMRawSpectrumData_h
#import <Foundation/Foundation.h>


@interface SMRawSpectrumData : NSObject
    
@property (nonatomic) NSArray<NSNumber*>* allBinsValues;
@property (nonatomic) double totalRawPow;
	
-(id) initWithArray: (NSArray<NSNumber*>*) binValues andTotalRawPow: (double) totalRawPow;
@end

#endif /* SMRawSpectrumData_h */
