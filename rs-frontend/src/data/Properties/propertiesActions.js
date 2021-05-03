import * as types from "../../constants/actionTypes";
import config from "../../config/config";
import PropertiesExternalService from "./propertiesExternalService";
import PropertiesService from "./propertiesService";

export function retrievePropertiesList() {
  return function (dispatch) {
    dispatch({ type: types.REQUEST_DEPARTED });
    let service = new PropertiesExternalService(config);
    service
      .retrievePropertiesList()
      .then((response) => {
        dispatch({ type: types.REQUEST_ARRIVED });
        dispatch({
          type: types.RETRIEVE_PROPERTIES_FULFILLED,
          payload: response,
        });
      })
      .catch((error) => {
        dispatch({ type: types.REQUEST_ARRIVED });
        dispatch({
          type: types.RETRIEVE_PROPERTIES_REJECTED,
          payload: error.response,
        });
      });
  };
}

export function saveOrUpdateProperty(
  id,
  address1,
  address2,
  city,
  state,
  zipCode,
  zipPlus4,
  yearBuilt,
  listPrice,
  monthlyRent
) {
  return function (dispatch) {
    dispatch({ type: types.REQUEST_DEPARTED });
    let service = new PropertiesService(config);
    service
      .saveOrUpdateProperty(
        id,
        address1,
        address2,
        city,
        state,
        zipCode,
        zipPlus4,
        yearBuilt,
        listPrice,
        monthlyRent
      )
      .then((response) => {
        dispatch({ type: types.REQUEST_ARRIVED });
        dispatch({
          type: types.SAVE_OR_UPDATE_FULFILLED,
          payload: response,
        });
      })
      .catch((error) => {
        dispatch({ type: types.REQUEST_ARRIVED });
        dispatch({
          type: types.SAVE_OR_UPDATE_REJECTED,
          payload: error.response,
        });
      });
  };
}

export function requestDeparted() {
  return function (dispatch) {
    return dispatch({
      type: types.REQUEST_DEPARTED,
    });
  };
}

export function requestArrived() {
  return function (dispatch) {
    return dispatch({
      type: types.REQUEST_ARRIVED,
    });
  };
}

export function clearSaveFlag() {
  return function (dispatch) {
    return dispatch({
      type: types.CLEAR_SAVE_FLAG,
    });
  };
}
