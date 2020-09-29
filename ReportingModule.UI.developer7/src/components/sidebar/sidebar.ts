import { containerless, autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";
import $ from "jquery";
import { AuthService } from "auth-service";

@containerless
@autoinject
export class Sidebar {
    constructor(public router: Router, public authservice: AuthService){}

    attached() {
        // TODO: sidebar.js code in appstack didn't run 
        // when loaded via aurelia
        if($) {
          $(".sidebar-toggle").on("click", function() {
              $(".sidebar")
                .toggleClass("toggled")
                // Triger resize after animation
                .one("transitionend", function() {
                  setTimeout(function() {
                    window.dispatchEvent(new Event("resize"));
                  }, 100);
                });
            });
        }
    }

    isUserVisible(roles: string[]): boolean {
      if(!roles || roles.length == 0) return true;
      const userRoles = this.authservice.roles;
      return roles.filter(role => userRoles.includes(role)).length != 0;
    }
}