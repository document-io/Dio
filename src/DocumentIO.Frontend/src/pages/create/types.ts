export interface CreateOrganizationType {
	name: string;
	accounts: CreateAccountType[] 
}

export interface CreateAccountType {
	login: string;
	email: string;
	firstName: string;
	middleName?: string;
	lastName: string;
	password: string;
}