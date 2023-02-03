import tabReducer from './tab/TabReducer';
import { applyMiddleware, createStore,combineReducers } from 'redux'
import thunk from 'redux-thunk';

const rootReducer = combineReducers({
    tabReducer
})

const store = createStore(rootReducer, applyMiddleware(thunk));

export default store;


