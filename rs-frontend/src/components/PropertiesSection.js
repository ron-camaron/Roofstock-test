import React from "react";
import Section from "./Section";
import Container from "@material-ui/core/Container";
import SectionHeader from "./SectionHeader";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import { getCurrencyFormattedNumber } from "../util/numberFormat";
import { Button } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  media: {
    height: 160,
  },
}));

const PropertiesSection = (props) => {
  const classes = useStyles();

  return (
    <Section
      bgColor={props.bgColor}
      size={props.size}
      bgImage={props.bgImage}
      bgImageOpacity={props.bgImageOpacity}
    >
      <Container>
        <SectionHeader
          title={props.title}
          subtitle={props.subtitle}
          size={4}
          textAlign="center"
        />
        <Grid container={true} justify="center" spacing={4}>
          {props.properties !== undefined
            ? props.properties.map((item, index) => (
                <Grid item={true} xs={12} md={6} lg={3} key={index}>
                  <Card>
                    <CardActionArea>
                      <CardMedia
                        image={item.mainImageUrl}
                        className={classes.media}
                      />
                      <CardContent>
                        <Typography
                          variant="body2"
                          component="p"
                          color={"textSecondary"}
                          gutterBottom={true}
                        >
                          {item.address.address1}
                          {item.address.address2}
                          {item.address.city}, {item.address.state} -{" "}
                          {item.address.zip}
                        </Typography>
                        <h5>
                          Year built:{" "}
                          {item.physical ? item.physical.yearBuilt : "unknown"}
                        </h5>
                        <h5>
                          List price:{" "}
                          {item.financial
                            ? getCurrencyFormattedNumber(
                                item.financial.listPrice
                              )
                            : "not indicated"}
                        </h5>
                        <h5>
                          Monthly rent:{" "}
                          {item.financial
                            ? getCurrencyFormattedNumber(
                                item.financial.monthlyRent
                              )
                            : "not indicated"}
                        </h5>
                        <h5>
                          Gross Yield:{" "}
                          {item.financial
                            ? (
                                ((item.financial.monthlyRent * 12) /
                                  item.financial.listPrice) *
                                100
                              ).toFixed(2) + "%"
                            : "not indicated"}
                        </h5>
                        <section>
                          <Button
                            id={item.id}
                            onClick={props.onSaveProperty}
                            variant="contained"
                            color="primary"
                            disabled={
                              props.requestDeparted && !props.requestArrived
                            }
                          >
                            Save
                          </Button>
                        </section>
                      </CardContent>
                    </CardActionArea>
                  </Card>
                </Grid>
              ))
            : null}
        </Grid>
      </Container>
    </Section>
  );
};

export default PropertiesSection;
