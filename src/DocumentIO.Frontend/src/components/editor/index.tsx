import React from 'react'
// Require Editor JS files.
import 'froala-editor/js/froala_editor.pkgd.min.js'
// Require Editor CSS files.
import 'froala-editor/css/froala_style.min.css'
import 'froala-editor/css/froala_editor.pkgd.min.css'
// Require Font Awesome.
import 'font-awesome/css/font-awesome.css'
// @ts-ignore
import FroalaEditor from 'react-froala-wysiwyg'

export const Editor = ({ setContent, content }: { setContent: (str: string) => void; content: string }) => {
  return <FroalaEditor
    tag='textarea'
    model={content}
    onModelChange={setContent}
  />
}