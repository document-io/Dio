import React, { FormEvent, useState } from "react"
import { Button, Form, Grid, Header, Message } from "semantic-ui-react"
import { ApolloError } from 'apollo-boost'
import { useMutation } from "@apollo/react-hooks"
import { RouteComponentProps } from "react-router"
import { LoginAccountType } from "./types"
import { LoginAccount, LoginAccountVariables } from "./mutations"

export const LoginPageTemplate = (props: RouteComponentProps) => {
	const [loading, setLoading] = useState(false)

	const [globalValidation, setGlobalValidation] = useState<string>("")
	
	const [email, setEmail] = useState<string>("")
	const [emailValidation, setEmailValidation] = useState<string>("")

	const [password, setPassword] = useState<string>("")
	const [passwordValidation, setPasswordValidation] = useState<string>("")

	const [loginAccount] = useMutation<LoginAccountType, LoginAccountVariables>(LoginAccount)

	const onSubmit = (event: FormEvent<HTMLFormElement>) => {
		event.preventDefault()

		setLoading(true)

		loginAccount({
			variables: {
				account: {
					email: email,
					password: password
			}}})
			.then(() => props.history.push('/dashboard'))
			.catch((reason: ApolloError) => {
				reason.graphQLErrors
					.forEach(error => {
						if (error.extensions === undefined) {
							setGlobalValidation(error.message)
							return;
						}

						const {extensions: {code}, message} = error;

						switch (code) {
							case 'email':
								setEmailValidation(message)
								break;

							case 'password':
								setPasswordValidation(message)
								break;

							case '':
								setGlobalValidation(message)
								break;
						}
					})

				setLoading(false)
			})
	}
	
	return (
		<Grid centered>
			<Grid.Column computer='7' mobile='12'>
				{
					globalValidation === ""
						? null
						: (
							<Message
								error
								content={globalValidation}
							/>
						)
				}

				<Form loading={ loading } onSubmit={ onSubmit }>
					{
						globalValidation === ""
							? (
								<Form.Field>
									<Grid>
										<Grid.Column textAlign='center'>
											<Header>Вход в систему</Header>
										</Grid.Column>
									</Grid>
								</Form.Field>
							)
							: null
					}
					

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
						error={ passwordValidation === "" ? null : {content: passwordValidation} }
						icon='low vision'
						iconPosition='left'
						placeholder='Введите ваш пароль'
						type='password'
						onChange={ (event, data) => {
							setPassword(data.value)
							setPasswordValidation("")
							setGlobalValidation("")
						} }
					/>

					<Grid>
						<Grid.Column textAlign='center'>
							<Button type='submit' basic color='black'>Войти</Button>
						</Grid.Column>
					</Grid>
				</Form>
			</Grid.Column>
		</Grid>
	)
}