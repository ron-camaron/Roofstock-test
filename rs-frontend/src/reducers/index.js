import { combineReducers } from 'redux';
import properties from './propertiesReducer';
import { connectRouter } from 'connected-react-router'

const rootReducer = history => combineReducers({
  router: connectRouter(history),
  properties,
});

export default rootReducer;
