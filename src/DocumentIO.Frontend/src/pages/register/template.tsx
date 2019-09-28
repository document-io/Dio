import React, { FormEvent, useState } from 'react'
import { RouteChildrenProps } from "react-router"
import { Button, Form, Grid, Header, Message } from "semantic-ui-react"
import { ApolloError } from "apollo-boost"
import { useMutation } from "@apollo/react-hooks"
import { CreateAccount, CreateAccountVariables } from "./mutations"
import { CreateAccountType } from "./types"

export const RegisterPageTemplate = (props: RouteChildrenProps<{ secret: string }>) => {
	const [loading, setLoading] = useState(false)
	const [globalValidation, setGlobalValidation] = useState<string>("")

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

	const [createAccount] = useMutation<CreateAccountType, CreateAccountVariables>(CreateAccount)

	const onSubmit = (event: FormEvent<HTMLFormElement>) => {
		event.preventDefault()

		setLoading(true)

		createAccount({
			variables: {
				// @ts-ignore
				secret: props.match.params.secret,
				account: {
					login: login,
					email: email,
					password: password === confirmPassword ? password : "",
					firstName: firstName,
					lastName: lastName
				}
			}
		})
			.then(() => props.history.push('/login'))
			.catch((reason: ApolloError) => {
				reason.graphQLErrors
					.forEach(error => {
						// @ts-ignore
						const {extensions: {code}, message} = error;

						switch (code) {

							case 'login':
								setLoginValidation(message)
								break;

							case 'email':
								setEmailValidation(message)
								break;

							case 'password':
								if (password === confirmPassword) {
									setPasswordValidation(message)
								}
								break;

							case 'firstName':
								setFirstNameValidation(message)
								break;

							case 'lastName':
								setLastNameValidation(message)
								break;

							default:
								setGlobalValidation(message)
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
		<Grid centered>
			<Grid.Column computer='7' mobile='12'>
				{
					globalValidation == ""
						? null
						: (
							<Message
								error
								content={ globalValidation }
							/>
						)
				}
				<Form loading={ loading } onSubmit={ onSubmit }>
					{
						globalValidation == ""
							? (
								<Form.Field>
									<Grid>
										<Grid.Column textAlign='center'>
											<Header>Регистрация</Header>
										</Grid.Column>
									</Grid>
								</Form.Field>
							)
							: null
					}

					<Form.Input
						error={ loginValidation === "" ? null : {content: loginValidation} }
						icon='bullhorn'
						iconPosition='left'
						placeholder='Введите ваш логин'
						onChange={ (event, data) => {
							setLogin(data.value)
							setLoginValidation("")
							setGlobalValidation("")
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
							setGlobalValidation("")
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
							setGlobalValidation("")
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
							setGlobalValidation("")
						} }
					/>

					<Form.Input
						error={ passwordValidation === "" ? null : {content: passwordValidation} }
						icon='low vision'
						iconPosition='left'
						type='password'
						placeholder='Введите ваш пароль'
						onChange={ (event, data) => {
							setPassword(data.value)
							setPasswordValidation("")
							setConfirmPasswordValidation("")
							setGlobalValidation("")
						} }
					/>

					<Form.Input
						error={ confirmPasswordValidation === "" ? null : {content: confirmPasswordValidation} }
						icon='map signs'
						iconPosition='left'
						type='password'
						placeholder='Повторите ваш пароль'
						onChange={ (event, data) => {
							setConfirmPassword(data.value)
							setConfirmPasswordValidation("")
							setPasswordValidation("")
							setGlobalValidation("")
						} }
					/>

					<Grid>
						<Grid.Column textAlign='center'>
							<Button type='submit' basic color='black'>Зарегистрироваться</Button>
						</Grid.Column>
					</Grid>
				</Form>
			</Grid.Column>
		</Grid>
	)
}