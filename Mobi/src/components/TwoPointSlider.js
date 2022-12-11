import {
    StyleSheet,
    Text,
    View
} from 'react-native'
import React from 'react'
import MultiSlider from '@ptomasroos/react-native-multi-slider'

import { COLORS, FONTS, SIZES, icons } from '../constants'

const TwoPointSlider = (
    { values, min, max, postfix, prefix, onValuesChange }) => {
    return (
        <MultiSlider
            values={values}
            sliderLength={SIZES.width - (SIZES.padding * 2) - 60}
            min={min}
            max={max}
            step={1}
            markerOffsetY={20}
            // phần được nhận giá trị
            selectedStyle={{
                backgroundColor: COLORS.primary
            }}
            trackStyle={{
                height: 15,
                borderRadius: 10,
                backgroundColor: COLORS.gray2
            }}
            // khoảng cách ngắn nhất 2 điểm
            minMarkerOverlapDistance={50}
            customMarker={(e) => {
                return (
                    <View
                        style={{
                            height: 60,
                            alignItems: 'center',
                            justifyContent: 'center',
                        }}
                    >
                        <View
                            style={{
                                height: 30,
                                width: 30,
                                borderRadius: 15,
                                backgroundColor: COLORS.primary,
                                borderWidth: 4,
                                borderColor: COLORS.white,
                                paddingHorizontal: 10,
                                ...styles.shadow
                            }}
                        />
                        <Text
                            style={{
                                width: 78,
                                left: 10,
                                alignSelf: 'center',
                                marginTop: 5,
                                ...FONTS.body3,
                                color: COLORS.darkGray
                            }}>
                            {prefix} {e.currentValue}{postfix}
                            {
                                console.log(e.currentValue)
                            }
                        </Text>
                    </View>
                )
            }}
            onValuesChange={(value) => onValuesChange(value)}
        />
    )
}

export default TwoPointSlider

const styles = StyleSheet.create({
    shadow: {
        shadowColor: '#000000'
    }
})