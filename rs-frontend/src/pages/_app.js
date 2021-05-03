import React from "react";
import Navbar from "./../components/Navbar";
import IndexPage from "./index";
import { Switch, Route, Router } from "./../util/router.js";
import NotFoundPage from "./not-found.js";
import Footer from "./../components/Footer";
import { ThemeProvider } from "./../util/theme.js";
import logo from "../assets/rs-logo-blue.png";

function App(props) {
  return (
    <ThemeProvider>
      <Router>
        <>
          <Navbar color="default" logo={logo} logoInverted={logo} />

          <Switch>
            <Route exact path="/" component={IndexPage} />
            <Route component={NotFoundPage} />
          </Switch>

          <Footer
            bgColor="default"
            size="medium"
            bgImage=""
            bgImageOpacity={1}
            description="Frontend part of an at-home technical challenge as part of the recruiting process."
            copyright="© 2021 Ronny Delgado"
            logo={logo}
            logoInverted={logo}
            sticky={true}
          />
        </>
      </Router>
    </ThemeProvider>
  );
}

export default App;
