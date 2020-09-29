import { Redirect } from "aurelia-router";
import { autoinject } from "aurelia-framework";

import { AuthService } from "auth-service";

@autoinject
export class AuthenticateStep {
  constructor(public auth: AuthService) {  }

  run(routingContext, next) {
    const isLoggedIn = this.auth.isAuthenticated;
    const loginRoute = "login";

    if (routingContext.getAllInstructions().some(route => route.config.auth === true)) {
      if (!isLoggedIn) {
        return next.cancel(new Redirect(loginRoute));
      }
    } else if (isLoggedIn && routingContext.getAllInstructions().some(route => route.fragment === loginRoute)) {
      return next.cancel(new Redirect("home"));
    }

    return next();
  }
}