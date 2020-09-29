import { Router, RouterConfiguration } from "aurelia-router";
import { PLATFORM } from 'aurelia-pal';
import { AuthenticateStep } from "authenticatestep";
import { RolesAuthoriseStep } from "rolesauthorisestep";

export class App {
  router: Router = null;
  configureRouter(config: RouterConfiguration, router: Router) {
    this.router = router;
    config.options.pushState = true;
    config.addAuthorizeStep(AuthenticateStep);
    config.addAuthorizeStep(RolesAuthoriseStep);
    config.map([
      // unauthenticated
      { route: [""], redirect: "welcome", nav: false },
      { route: ["login", "Welcome"], name: "welcome", href: "welcome", moduleId: PLATFORM.moduleName("components/welcome/welcome"), nav: true, title: "Welcome" },
      { route: ["support", "Support"], name: "support", href: "support", moduleId: PLATFORM.moduleName("components/support/support"), nav: true, title: "Support" },
      // auth0
      { route: 'callback', name: 'callback', moduleId: PLATFORM.moduleName("callback"), nav: false },

      // authenticated
      { route: "dashboard", name: "dashboard", href: "dashboard", moduleId: PLATFORM.moduleName("components/dashboard/dashboard"), nav: true, auth: true, title: "Dashboard" },
      { route: "plans-and-reports", name: "plans-and-reports", href: "plans-and-reports", moduleId: PLATFORM.moduleName("components/plans-and-reports/plans-and-reports"), nav: true, auth: true, title: "Plans and Reports" },
      { route: "manage-organizations", name: "manage-organizations", href: "manage-organizations", moduleId: PLATFORM.moduleName("components/manage-organizations/manage-organizations"), nav: true, auth: true, roles: ["sysadmin"], title: "Manage Organizations" },
      { route: "manage-organization-users", name: "manage-organization-users", href: "manage-organization-users", moduleId: PLATFORM.moduleName("components/manage-organization-users/manage-organization-users"), nav: true, auth: true, roles: ["sysadmin"], title: "User Administration" },

      { route: "plan-create", name: "plan-create", href: "plan-create", moduleId: PLATFORM.moduleName("components/plan-create/plan-create"), nav: false, auth: true, roles: ["sysadmin"], title: "New Plan" },

      { route: "unit-plan-view/:planid", name: "unit-plan-view", href: "unit-plan-view", moduleId: PLATFORM.moduleName("components/unit-plan-view/unit-plan-view"), nav: false, auth: true, title: "View Unit Plan" },
      { route: "unit-plan-edit/:planid", name: "unit-plan-edit", href: "unit-plan-edit", moduleId: PLATFORM.moduleName("components/unit-plan-edit/unit-plan-edit"), nav: false, auth: true, title: "Edit Unit Plan" },
      { route: "unit-report-view/:reportid", name: "unit-report-view", href: "unit-report-view", moduleId: PLATFORM.moduleName("components/unit-report-view/unit-report-view"), nav: false, auth: true, title: "View Unit Report" },
      { route: "unit-report-edit/:reportid", name: "unit-report-edit", href: "unit-report-edit", moduleId: PLATFORM.moduleName("components/unit-report-edit/unit-report-edit"), nav: false, auth: true, title: "Edit Unit Report" },
      { route: "unit-plan-copy/:planid", name: "unit-plan-copy", href: "unit-plan-copy", moduleId: PLATFORM.moduleName("components/unit-plan-copy/unit-plan-copy"), nav: false, auth: true, title: "Copy Unit Plan" },
      {
        route: "unit-report-lastperiod-edit/:reportid",
        name: "unit-report-lastperiod-edit",
        href: "unit-report-lastperiod-edit",
        moduleId: PLATFORM.moduleName("components/unit-report-lastperiod-edit/unit-report-lastperiod-edit"),
        nav: false, auth: true, roles: ["sysadmin"], title: "Edit Unit Report Last Period"
      },

      { route: "state-plan-view/:planid", name: "state-plan-view", href: "state-plan-view", moduleId: PLATFORM.moduleName("components/state-plan-view/state-plan-view"), nav: false, auth: true, title: "View State Plan" },
      { route: "state-plan-edit/:planid", name: "state-plan-edit", href: "state-plan-edit", moduleId: PLATFORM.moduleName("components/state-plan-edit/state-plan-edit"), nav: false, auth: true, title: "Edit State Plan" },
      { route: "state-report-view/:reportid", name: "state-report-view", href: "state-report-view", moduleId: PLATFORM.moduleName("components/state-report-view/state-report-view"), nav: false, auth: true, title: "View State Report" },
      { route: "state-report-edit/:reportid", name: "state-report-edit", href: "state-report-edit", moduleId: PLATFORM.moduleName("components/state-report-edit/state-report-edit"), nav: false, auth: true, title: "Edit State Report" },
      { route: "state-plan-copy/:planid", name: "state-plan-copy", href: "state-plan-copy", moduleId: PLATFORM.moduleName("components/state-plan-copy/state-plan-copy"), nav: false, auth: true, title: "Copy State Plan" },
      {
        route: "state-report-lastperiod-edit/:reportid",
        name: "state-report-lastperiod-edit",
        href: "state-report-lastperiod-edit",
        moduleId: PLATFORM.moduleName("components/state-report-lastperiod-edit/state-report-lastperiod-edit"),
        nav: false, auth: true, roles: ["sysadmin"], title: "Edit State Report Last Period"
      },

      { route: "zone-plan-view/:planid", name: "zone-plan-view", href: "zone-plan-view", moduleId: PLATFORM.moduleName("components/zone-plan-view/zone-plan-view"), nav: false, auth: true, title: "View Zone Plan" },
      { route: "zone-plan-edit/:planid", name: "zone-plan-edit", href: "zone-plan-edit", moduleId: PLATFORM.moduleName("components/zone-plan-edit/zone-plan-edit"), nav: false, auth: true, title: "Edit Zone Plan" },
      { route: "zone-report-view/:reportid", name: "zone-report-view", href: "zone-report-view", moduleId: PLATFORM.moduleName("components/zone-report-view/zone-report-view"), nav: false, auth: true, title: "View Zone Report" },
      { route: "zone-report-edit/:reportid", name: "zone-report-edit", href: "zone-report-edit", moduleId: PLATFORM.moduleName("components/zone-report-edit/zone-report-edit"), nav: false, auth: true, title: "Edit Zone Report" },
      { route: "zone-plan-copy/:planid", name: "zone-plan-copy", href: "zone-plan-copy", moduleId: PLATFORM.moduleName("components/zone-plan-copy/zone-plan-copy"), nav: false, auth: true, title: "Copy Zone Plan" },
      {
        route: "zone-report-lastperiod-edit/:reportid",
        name: "zone-report-lastperiod-edit",
        href: "zone-report-lastperiod-edit",
        moduleId: PLATFORM.moduleName("components/zone-report-lastperiod-edit/zone-report-lastperiod-edit"),
        nav: false, auth: true, roles: ["sysadmin"], title: "Edit Zone Report Last Period"
      },

      { route: "central-plan-view/:planid", name: "central-plan-view", href: "central-plan-view", moduleId: PLATFORM.moduleName("components/central-plan-view/central-plan-view"), nav: false, auth: true, title: "View Central Plan" },
      { route: "central-plan-edit/:planid", name: "central-plan-edit", href: "central-plan-edit", moduleId: PLATFORM.moduleName("components/central-plan-edit/central-plan-edit"), nav: false, auth: true, title: "Edit Central Plan" },
      { route: "central-report-view/:reportid", name: "central-report-view", href: "central-report-view", moduleId: PLATFORM.moduleName("components/central-report-view/central-report-view"), nav: false, auth: true, title: "View Central Report" },
      { route: "central-report-edit/:reportid", name: "central-report-edit", href: "central-report-edit", moduleId: PLATFORM.moduleName("components/central-report-edit/central-report-edit"), nav: false, auth: true, title: "Edit Central Report" },
      { route: "central-plan-copy/:planid", name: "central-plan-copy", href: "central-plan-copy", moduleId: PLATFORM.moduleName("components/central-plan-copy/central-plan-copy"), nav: false, auth: true, title: "Copy Central Plan" },
      {
        route: "central-report-lastperiod-edit/:reportid",
        name: "central-report-lastperiod-edit",
        href: "central-report-lastperiod-edit",
        moduleId: PLATFORM.moduleName("components/central-report-lastperiod-edit/central-report-lastperiod-edit"),
        nav: false, auth: true, roles: ["sysadmin"], title: "Edit Central Report Last Period"
      },

      { route: "organization-create", name: "organization-create", href: "organization-create", moduleId: PLATFORM.moduleName("components/organization-create/organization-create"), nav: false, auth: true, roles: ["sysadmin"], title: "New Organization" },
      { route: "organization-edit/:organizationId", name: "organization-edit", href: "organization-edit", moduleId: PLATFORM.moduleName("components/organization-edit/organization-edit"), nav: false, auth: true, title: "Edit Organization" },
    
      { route: "organization-user-create", name: "organization-user-create", href: "organization-user-create", moduleId: PLATFORM.moduleName("components/organization-user-create/organization-user-create"), nav: false, auth: true, roles: ["sysadmin"], title: "New Organization User" },

      { route: "admin", name: "admin", href: "admin", moduleId: PLATFORM.moduleName("components/admin/admin"), nav: true, auth: true, roles: ["sysadmin"], title: "Admin Tools" },

      { route: "analytic-reports", name: "analytic-reports", href: "analytic-reports", moduleId: PLATFORM.moduleName("components/analytic-reports/analytic-reports"), nav: true, auth: true, title: "Analytic Reports" },
      { route: "analytic-report-create", name: "analytic-report-create", href: "analytic-report-create", moduleId: PLATFORM.moduleName("components/analytic-report-create/analytic-report-create"), nav: false, auth: true, title: "Create New Analytic Report" },
      { route: "support-auth", name: "support-auth", href: "support-auth", moduleId: PLATFORM.moduleName("components/support/support"), nav: true, auth:true, title: "Support" },
    ])
  }
}
