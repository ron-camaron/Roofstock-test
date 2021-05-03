import * as types from "../constants/actionTypes";

const initialState = {
  propertiesList: [],
  requestDeparted: false,
  requestArrived: true,
  errorSaving: null,
  allSaved: null,
};

export default function propertiesReducer(state = initialState, action) {
  switch (action.type) {
    case types.RETRIEVE_PROPERTIES_FULFILLED: {
      let data = action.payload.data;
      return {
        ...state,
        propertiesList: data,
      };
    }

    case types.RETRIEVE_PROPERTIES_REJECTED: {
      return {
        ...state,
      };
    }

    case types.SAVE_OR_UPDATE_FULFILLED: {
      return {
        ...state,
        allSaved: true,
      };
    }

    case types.SAVE_OR_UPDATE_REJECTED: {
      debugger;
      let error = "";
      if (action.payload === undefined) {
        error = "Cannot connect with API";
      }

      return {
        ...state,
        errorSaving: error,
        allSaved: false,
      };
    }

    case types.REQUEST_DEPARTED: {
      return {
        ...state,
        requestDeparted: true,
        requestArrived: false,
      };
    }

    case types.REQUEST_ARRIVED: {
      return {
        ...state,
        requestArrived: true,
        requestDeparted: false,
      };
    }

    case types.CLEAR_SAVE_FLAG: {
      return {
        ...state,
        allSaved: null,
      };
    }

    default:
      return state;
  }
}
