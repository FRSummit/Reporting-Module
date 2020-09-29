; With X As
    (
        select OrganizationDescription 
        From Report 
		Where OrganizationOrganizationType = 1
    )

Update X set OrganizationDescription = OrganizationDescription + ', President: Mohammad Mostadir, State: Victoria.'

