import React, { FormEvent, useState } from "react"
import { Button, Form, Grid, Header, Message } from "semantic-ui-react"

import { ApolloError } from 'apollo-boost'
import { useMutation } from "@apollo/react-hooks"
import { CreateOrganizationType } from "./types"
import { CreateOrganization, CreateOrganizationVariables } from "./mutations"
import { RouteComponentProps } from "react-router"

export const CreatePageContent = (props: RouteComponentProps) => {
	const [loading, setLoading] = useState(false)
	const [success, setSuccess] = useState(false)

	const [name, setName] = useState<string>("")
	const [nameValidation, setNameValidation] = useState<string>("")

	const [login, setLogin] = useState<string>("")
	const [loginValidation, setLoginValidation] = useState<string>("")

	const [email, setEmail] = useState<string>("")
	const [emailValidation, setEmailValidation] = useState<string>("")

	const [firstName, setFirstName] = useState<string>("")
	const [firstNameValidation, setFirstNameValidation] = useState<string>("")

	const [lastName, setLastName] = useState<string>("")
	const [lastNameValidation, setLastNameValidation] = useState<string>("")

	const [password, setPassword] = useState<string>("")
	const [passwordValidation, setPasswordValidation] = useState<string>("")

	const [confirmPassword, setConfirmPassword] = useState<string>("")
	const [confirmPasswordValidation, setConfirmPasswordValidation] = useState<string>("")

	const [createOrganization,] = useMutation<CreateOrganizationType,
		CreateOrganizationVariables>(CreateOrganization)

	const onSubmit = (event: FormEvent<HTMLFormElement>) => {
		event.preventDefault()

		setLoading(true)

		createOrganization({
			variables: {
				organization: {
					name,
					accounts: [{
						login,
						email,
						password: password === confirmPassword ? password : '',
						lastName,
						firstName
					}]
				}
			}
		})
			.then(value => {
				setSuccess(true)
				setTimeout(() => props.history.push('/login'), 200)
			})
			.catch((reason: ApolloError) => {
				reason.graphQLErrors
					.forEach(error => {
						// @ts-ignore
						const {extensions: {code}, message} = error;

						switch (code) {
							case 'name':
								setNameValidation(message)
								break;

							case 'accounts[0].login':
								setLoginValidation(message)
								break;

							case 'accounts[0].email':
								setEmailValidation(message)
								break;

							case 'accounts[0].password':
								if (password === confirmPassword) {
									setPasswordValidation(message)
								}
								break;

							case 'accounts[0].firstName':
								setFirstNameValidation(message)
								break;

							case 'accounts[0].lastName':
								setLastNameValidation(message)
								break;
						}
					})

				if (password !== confirmPassword) {
					const message = "Пароли не совпадают"

					setPasswordValidation(message)
					setConfirmPasswordValidation(message)
				}

				setLoading(false)
			})
	}

	return (
		<Grid centered columns='2'>
			<Grid.Column>

				{success ? (
					<Message
						success
						header='Организация создана'
						content={ `Организация '${ name }' успешно создана` } />) : null}

				<Form loading={ loading } onSubmit={ onSubmit }>
					<Form.Input
						error={ nameValidation === "" ? null : {content: nameValidation} }
						icon='building'
						iconPosition='left'
						placeholder='Введите название организации'
						onChange={ (event, data) => {
							setName(data.value)
							setNameValidation("")
						} }
					/>

					<Form.Input
						error={ loginValidation === "" ? null : {content: loginValidation} }
						icon='bullhorn'
						iconPosition='left'
						placeholder='Введите ваш логин'
						onChange={ (event, data) => {
							setLogin(data.value)
							setLoginValidation("")
						} }
					/>

					<Form.Input
						error={ emailValidation === "" ? null : {content: emailValidation} }
						icon='at'
						iconPosition='left'
						placeholder='Введите ваш email'
						onChange={ (event, data) => {
							setEmail(data.value)
							setEmailValidation("")
						} }
					/>

					<Form.Input
						error={ firstNameValidation === "" ? null : {content: firstNameValidation} }
						icon='address card'
						iconPosition='left'
						placeholder='Введите ваше имя'
						onChange={ (event, data) => {
							setFirstName(data.value)
							setFirstNameValidation("")
						} }
					/>

					<Form.Input
						error={ lastNameValidation === "" ? null : {content: lastNameValidation} }
						icon='address card outline'
						iconPosition='left'
						placeholder='Введите вашу фамилию'
						onChange={ (event, data) => {
							setLastName(data.value)
							setLastNameValidation("")
						} }
					/>

					<Form.Input
						error={ passwordValidation === "" ? null : {content: passwordValidation} }
						icon='low vision'
						iconPosition='left'
						placeholder='Введите ваш пароль'
						onChange={ (event, data) => {
							setPassword(data.value)
							setPasswordValidation("")
							setConfirmPasswordValidation("")
						} }
					/>

					<Form.Input
						error={ confirmPasswordValidation === "" ? null : {content: confirmPasswordValidation} }
						icon='map signs'
						iconPosition='left'
						placeholder='Повторите ваш пароль'
						onChange={ (event, data) => {
							setConfirmPassword(data.value)
							setConfirmPasswordValidation("")
							setPasswordValidation("")
						} }
					/>

					<Grid>
						<Grid.Column textAlign='center'>
							<Button type='submit' basic color='black'>Создать организацию</Button>
						</Grid.Column>
					</Grid>
				</Form>
			</Grid.Column>
		</Grid>
	)
}