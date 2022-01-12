import 'primevue/resources/themes/saga-blue/theme.css';
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';
import 'primeflex/primeflex.css';
import './assets/sass/layout.scss';
import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import InputText from 'primevue/inputtext';
import Menubar from 'primevue/menubar';
import InputNumber from 'primevue/inputnumber';
import Card from 'primevue/card';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';


const app = createApp(App);

app.use(PrimeVue);

app.component('Button', Button);
app.component('InputText', InputText);
app.component('Menubar', Menubar);
app.component('InputNumber', InputNumber);
app.component('Card', Card);
app.component('DataTable', DataTable);
app.component('Column', Column);

app.mount('#app')
