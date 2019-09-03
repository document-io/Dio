import React from 'react'

export const App: React.FC = () => {

	const [message, setMessage] = React.useState('')

	const updateMessage = () => fetch('test').then(async res => setMessage(await res.text()))

	return (
		<div>
			{message}
			<button onClick={() => fetch('test/signin').then(async () => await updateMessage())}>
        Sign In
			</button>
			<button onClick={() => fetch('test/signout').then(async () => await updateMessage())}>
        Sign Out
			</button>
		</div>
	)
}