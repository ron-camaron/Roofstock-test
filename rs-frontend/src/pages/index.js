import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import HeroSection from "./../components/HeroSection";
import PropertiesSection from "../components/PropertiesSection";
import * as actions from "../data/Properties/propertiesActions";
import { Snackbar } from "@material-ui/core";
import { Alert } from "@material-ui/lab";

const IndexPage = (props) => {
  const [successSnack, setSuccessSnack] = useState(false);
  const [errorSnack, setErrorSnack] = useState(false);

  const list = useSelector((state) => state.properties.propertiesList);
  const requestDeparted = useSelector(
    (state) => state.properties.requestDeparted
  );
  const requestArrived = useSelector(
    (state) => state.properties.requestArrived
  );
  const allSaved = useSelector((state) => state.properties.allSaved);

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(actions.retrievePropertiesList());
  }, []);

  useEffect(() => {
    if (allSaved !== null && allSaved) {
      setSuccessSnack(true);
      dispatch(actions.clearSaveFlag());
    } else if (allSaved !== null && !allSaved) {
      setErrorSnack(true);
      dispatch(actions.clearSaveFlag());
    }
  }, [allSaved]);

  const onSaveProperty = (e) => {
    let id = parseInt(e.currentTarget.id);
    let property = list.properties.find((item) => {
      return item.id === id;
    });

    let address1 = null;
    let address2 = null;
    let city = null;
    let state = null;
    let zip = null;
    let zipPlus4 = null;

    if (property.address !== null) {
      address1 = property.address.address1;
      address2 = property.address.address2;
      city = property.address.city;
      state = property.address.state;
      zip = property.address.zip;
      zipPlus4 = property.address.zipPlus4;
    }

    let yearBuilt =
      property.physical !== null ? property.physical.yearBuilt : null;

    let listPrice = null;
    let monthlyRent = null;
    if (property.financial !== null) {
      listPrice = property.financial.listPrice;
      monthlyRent = property.financial.monthlyRent;
    }

    dispatch(
      actions.saveOrUpdateProperty(
        property.id,
        address1,
        address2,
        city,
        state,
        zip,
        zipPlus4,
        yearBuilt,
        listPrice,
        monthlyRent
      )
    );
  };

  return (
    <>
      <HeroSection
        bgColor="primary"
        size="large"
        bgImage="https://source.unsplash.com/1600x800/?house,building"
        bgImageOpacity={0.3}
        title="Build wealth through real estate"
        subtitle="Roofstock makes investing in single-family properties radically simple."
      />
      <PropertiesSection
        bgColor="default"
        size="medium"
        bgImage=""
        bgImageOpacity={1}
        title="List of Properties"
        subtitle=""
        properties={list.properties}
        onSaveProperty={onSaveProperty}
        requestDeparted={requestDeparted}
        requestArrived={requestArrived}
      />
      <Snackbar
        anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
        open={successSnack}
        autoHideDuration={4000}
        onClose={() => setSuccessSnack(false)}
      >
        <Alert severity="success">All saved successfully!</Alert>
      </Snackbar>
      <Snackbar
        anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
        open={errorSnack}
        autoHideDuration={4000}
        onClose={() => setErrorSnack(false)}
      >
        <Alert severity="error">
          Oops! There was an error saving that one.
        </Alert>
      </Snackbar>
    </>
  );
};

export default IndexPage;
