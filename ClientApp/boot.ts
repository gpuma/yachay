import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import Snotify from 'vue-snotify'; 

Vue.use(VueRouter);
Vue.use(Snotify);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/students', component: require('./components/fetchstudents/fetchstudents.vue.html') },
    { path: '/students/:id', component: require('./components/student/student.vue.html') },
    { path: '/units', component: require('./components/fetchunits/fetchunits.vue.html') },
    { path: '/units/:id', component: require('./components/unit/unit.vue.html') },
    { path: '/units/:id/enroll', component: require('./components/enrollstudents/enrollstudents.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),
});
