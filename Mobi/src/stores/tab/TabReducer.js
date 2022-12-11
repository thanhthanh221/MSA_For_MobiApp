import { constants } from '../../constants';
import * as tabActionTypes from './TabActions';

// dữ liệu ban đầu
const initalState = {
    selectedTab: constants.screens.home,
}
const tabReducer = (state = initalState, action) => {
    switch (action.type) {
        case tabActionTypes.SET_SELECTED_TAB:
            return {
                ...state,
                selectedTab: action.payload.selectedTab
            }
        default:
            return state
    }
}
export default tabReducer;