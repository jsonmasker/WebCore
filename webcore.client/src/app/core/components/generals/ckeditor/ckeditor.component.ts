// /**
//  * This configuration was generated using the CKEditor 5 Builder. You can modify it anytime using this link:
//  * https://ckeditor.com/ckeditor-5/builder/?redirect=portal#installation/NoNgNARATAdAzPCkAsc4AYAcUCsnkCcOAjMVCCHCOuVnFFugegOwtpTHLJIQCmAOyTowwYmBEjxUgLqQAZnD4ATYi3QQZQA=
//  */

// import { Component, EventEmitter, Input, Output, ViewEncapsulation, type OnInit } from '@angular/core';
// import { CommonModule, NgIf } from '@angular/common';
// import { loadCKEditorCloud, CKEditorModule, type CKEditorCloudResult, type CKEditorCloudConfig, ChangeEvent } from '@ckeditor/ckeditor5-angular';

// import type { ClassicEditor, EditorConfig } from 'https://cdn.ckeditor.com/typings/ckeditor5.d.ts';

// const LICENSE_KEY =
// 	'eyJhbGciOiJFUzI1NiJ9.eyJleHAiOjE3NzQ4Mjg3OTksImp0aSI6IjE2MjMwN2JlLTNmNTAtNDJhMS05ZjA3LTE2NTNiMzhlY2VhYiIsImxpY2Vuc2VkSG9zdHMiOlsiMTI3LjAuMC4xIiwibG9jYWxob3N0IiwiMTkyLjE2OC4qLioiLCIxMC4qLiouKiIsIjE3Mi4qLiouKiIsIioudGVzdCIsIioubG9jYWxob3N0IiwiKi5sb2NhbCJdLCJ1c2FnZUVuZHBvaW50IjoiaHR0cHM6Ly9wcm94eS1ldmVudC5ja2VkaXRvci5jb20iLCJkaXN0cmlidXRpb25DaGFubmVsIjpbImNsb3VkIiwiZHJ1cGFsIl0sImxpY2Vuc2VUeXBlIjoiZGV2ZWxvcG1lbnQiLCJmZWF0dXJlcyI6WyJEUlVQIiwiQk9YIl0sInZjIjoiMjViYzJhZTEifQ.7ubAJqLahpd1Gr_wV5pXJ2hP7EuI1VyWUGA0y8edbco3dShWggCVi7AypWVpPgZ4VQguA2i7JbTjUOS5tlpTOw';

// const cloudConfig = {
// 	version: '44.3.0'
// } satisfies CKEditorCloudConfig;

// @Component({
// 	selector: 'app-ckeditor',
// 	  standalone: true,
// 	  imports: [CommonModule, CKEditorModule, NgIf],
// 		templateUrl: './ckeditor.component.html',
// 		styleUrl: './ckeditor.component.scss',
// 	  encapsulation: ViewEncapsulation.None
//   })
// export class CkeditorComponent implements OnInit {
// 	public Editor: typeof ClassicEditor | null = null;
// 	public config: EditorConfig | null = null;
// 	@Input() initialData: string = '';
// 	@Output() result: EventEmitter<string> = new EventEmitter<string>();

// 	public onChange( { editor }: ChangeEvent ) {
//         const data = editor.getData();
//         this.result.emit(data);
//     }
// 	public ngOnInit(): void {
// 		loadCKEditorCloud(cloudConfig).then(this._setupEditor.bind(this));
// 	}

// 	private _setupEditor(cloud: CKEditorCloudResult<typeof cloudConfig>) {
// 		const {
// 			ClassicEditor,
// 			Autoformat,
// 			AutoImage,
// 			Autosave,
// 			BlockQuote,
// 			Bold,
// 			CloudServices,
// 			Emoji,
// 			Essentials,
// 			Heading,
// 			ImageBlock,
// 			ImageCaption,
// 			ImageInline,
// 			ImageInsertViaUrl,
// 			ImageResize,
// 			ImageStyle,
// 			ImageTextAlternative,
// 			ImageToolbar,
// 			ImageUpload,
// 			Indent,
// 			IndentBlock,
// 			Italic,
// 			Link,
// 			LinkImage,
// 			List,
// 			ListProperties,
// 			MediaEmbed,
// 			Mention,
// 			Paragraph,
// 			PasteFromOffice,
// 			Table,
// 			TableCaption,
// 			TableCellProperties,
// 			TableColumnResize,
// 			TableProperties,
// 			TableToolbar,
// 			TextTransformation,
// 			TodoList,
// 			Underline
// 		} = cloud.CKEditor;

// 		this.Editor = ClassicEditor;
// 		this.config = {
// 			toolbar: {
// 				items: [
// 					'heading',
// 					'|',
// 					'bold',
// 					'italic',
// 					'underline',
// 					'|',
// 					'emoji',
// 					'link',
// 					'mediaEmbed',
// 					'insertTable',
// 					'blockQuote',
// 					'|',
// 					'bulletedList',
// 					'numberedList',
// 					'todoList',
// 					'outdent',
// 					'indent'
// 				],
// 				shouldNotGroupWhenFull: false
// 			},
// 			plugins: [
// 				Autoformat,
// 				AutoImage,
// 				Autosave,
// 				BlockQuote,
// 				Bold,
// 				CloudServices,
// 				Emoji,
// 				Essentials,
// 				Heading,
// 				ImageBlock,
// 				ImageCaption,
// 				ImageInline,
// 				ImageInsertViaUrl,
// 				ImageResize,
// 				ImageStyle,
// 				ImageTextAlternative,
// 				ImageToolbar,
// 				ImageUpload,
// 				Indent,
// 				IndentBlock,
// 				Italic,
// 				Link,
// 				LinkImage,
// 				List,
// 				ListProperties,
// 				MediaEmbed,
// 				Mention,
// 				Paragraph,
// 				PasteFromOffice,
// 				Table,
// 				TableCaption,
// 				TableCellProperties,
// 				TableColumnResize,
// 				TableProperties,
// 				TableToolbar,
// 				TextTransformation,
// 				TodoList,
// 				Underline
// 			],
// 			heading: {
// 				options: [
// 					{
// 						model: 'paragraph',
// 						title: 'Paragraph',
// 						class: 'ck-heading_paragraph'
// 					},
// 					{
// 						model: 'heading1',
// 						view: 'h1',
// 						title: 'Heading 1',
// 						class: 'ck-heading_heading1'
// 					},
// 					{
// 						model: 'heading2',
// 						view: 'h2',
// 						title: 'Heading 2',
// 						class: 'ck-heading_heading2'
// 					},
// 					{
// 						model: 'heading3',
// 						view: 'h3',
// 						title: 'Heading 3',
// 						class: 'ck-heading_heading3'
// 					},
// 					{
// 						model: 'heading4',
// 						view: 'h4',
// 						title: 'Heading 4',
// 						class: 'ck-heading_heading4'
// 					},
// 					{
// 						model: 'heading5',
// 						view: 'h5',
// 						title: 'Heading 5',
// 						class: 'ck-heading_heading5'
// 					},
// 					{
// 						model: 'heading6',
// 						view: 'h6',
// 						title: 'Heading 6',
// 						class: 'ck-heading_heading6'
// 					}
// 				]
// 			},
// 			image: {
// 				toolbar: [
// 					'toggleImageCaption',
// 					'imageTextAlternative',
// 					'|',
// 					'imageStyle:inline',
// 					'imageStyle:wrapText',
// 					'imageStyle:breakText',
// 					'|',
// 					'resizeImage'
// 				]
// 			},
// 			initialData:'',
// 			licenseKey: LICENSE_KEY,
// 			link: {
// 				addTargetToExternalLinks: true,
// 				defaultProtocol: 'https://',
// 				decorators: {
// 					toggleDownloadable: {
// 						mode: 'manual',
// 						label: 'Downloadable',
// 						attributes: {
// 							download: 'file'
// 						}
// 					}
// 				}
// 			},
// 			list: {
// 				properties: {
// 					styles: true,
// 					startIndex: true,
// 					reversed: true
// 				}
// 			},
// 			mention: {
// 				feeds: [
// 					{
// 						marker: '@',
// 						feed: [
// 							/* See: https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html */
// 						]
// 					}
// 				]
// 			},
// 			placeholder: 'Type or paste your content here!',
// 			table: {
// 				contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties']
// 			}
// 		};
// 	}
// }
